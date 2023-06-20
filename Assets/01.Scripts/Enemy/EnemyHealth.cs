using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

public class EnemyHealth : PoolableMono, IDamageable
{
    [SerializeField]
    private LayerMask _whatIsGround;

    [SerializeField]
    private int _maxHP;
    private int _currentHP;

    [SerializeField]
    private float _timeSlow;
    [SerializeField]
    private float _timeSlowTime;
    [SerializeField]
    private float _shakeScreen;

    public bool IsDead;

    public UnityEvent OnDeadTriggered;

    private void Start()
    {
        _currentHP = _maxHP;
    }

    public void OnDamage(int damage)
    {
        if (IsDead) return;
        _currentHP -= damage;
        StartCoroutine(TimeSlow());
        CameraManager.Instance.CamShake(_shakeScreen);

        //RaycastHit hit;
        //if (Physics.Raycast(point, Vector3.down, out hit, 10f, _whatIsGround))
        //{
        //    Quaternion look = Quaternion.LookRotation(normal);
        //    VisualEffect effect = Instantiate(_bloodEffect, point, look);

        //    effect.SetFloat(_heightHash, -hit.distance);
        //    effect.Play();
        //    Destroy(effect.gameObject, 3f);
        //}
        Debug.Log(_currentHP);
        _currentHP = Mathf.Clamp(_currentHP, 0, _maxHP);
        if (_currentHP <= 0)
        {
            IsDead = true;
            OnDeadTriggered?.Invoke();
            GameManager.Instance.killCnt++;
        }
    }

    private IEnumerator TimeSlow()
    {
        Time.timeScale = _timeSlow;
        yield return new WaitForSeconds(_timeSlowTime);
        Time.timeScale = 1f;
    }

    public void ClearEnemy()
    {
        StartCoroutine(Clear());
    }

    private IEnumerator Clear()
    {
        yield return new WaitForSeconds(1f);
        PoolManager.Instance.Push(this);
    }

    public override void Init()
    {
        
    }
}
