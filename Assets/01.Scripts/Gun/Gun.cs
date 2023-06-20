using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Transform _firePosTrm;
    private Light _muzzleLight;
    private LineRenderer _lineRenderer;

    [SerializeField]
    private LayerMask _whatIsEnemy;

    [Header("총 설정")]
    [SerializeField]
    private float _spread;
    [SerializeField]
    private float _fireDistance;
    [SerializeField]
    private float _coolTime = 0.2f;
    [SerializeField]
    private int _gunDamage = 10;

    private float _lastFireTime;

    [Header("장전관련")]
    public bool isReload;
    [SerializeField]
    private int _maxBulletCnt;
    public int _currentBulletCnt;

    [SerializeField]
    private float _reloadTime;

    private void Awake()
    {
        _firePosTrm = transform.Find("FirePosition");
        _muzzleLight = transform.Find("FirePosition/MuzzleLight").GetComponent<Light>();
        _lineRenderer = GetComponent<LineRenderer>();
        _currentBulletCnt = _maxBulletCnt;
    }

    private void Update()
    {
        UIManager.Instance.BulletUI(_currentBulletCnt, _maxBulletCnt);
    }

    public void Fire()
    {
        if (_lastFireTime + _coolTime < Time.time && isReload == false)
        {
            _lastFireTime = Time.time;

            RaycastHit hit;

            _lineRenderer.enabled = true;
            _muzzleLight.enabled = true;
            _lineRenderer.positionCount = 2;
            _lineRenderer.SetPosition(0, _firePosTrm.position);
            Vector3 startPos = _firePosTrm.position + _firePosTrm.forward * -1f;

            float x = Random.Range(-_spread, _spread);
            float y = Random.Range(-_spread, _spread);

            //총 바로 앞에 있는 좀비를 맞추려면 총길이만큼 빼서 레이를 쏴야한다.
            if (Physics.Raycast(startPos, _firePosTrm.forward + new Vector3(x, y, 0), out hit, _fireDistance, _whatIsEnemy))
            {
                _currentBulletCnt--;
                _lineRenderer.SetPosition(1, hit.point);

                if (hit.collider.TryGetComponent(out IDamageable health))
                {
                    Debug.Log(hit.collider);
                    health.OnDamage(_gunDamage);
                }
                if(_currentBulletCnt <= 0)
                {
                    isReload = true;
                }
            }
            else
            {
                _lineRenderer.SetPosition(1, _firePosTrm.position + _firePosTrm.forward * _fireDistance);
            }

            StartCoroutine(EffectDelay());
        }
    }

    public void ReloadGun()
    {
        isReload = true;
        StartCoroutine(Reloading());
    }

    private IEnumerator Reloading()
    {
        yield return new WaitForSeconds(_reloadTime);
        _currentBulletCnt = _maxBulletCnt;
        isReload = false;
    }

    private IEnumerator EffectDelay()
    {
        yield return new WaitForSeconds(0.05f);
        _lineRenderer.enabled = false;
        _muzzleLight.enabled = false;
    }
}
