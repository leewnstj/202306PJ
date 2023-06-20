using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerRollingAttack : MonoBehaviour
{
    [SerializeField] private float _chargeSpeed;
    [SerializeField] private float _maxPower;
    public float _currentPowerSpeed;
    public float _currentPower;


    public Vector3 dir;

    private InputAgent _input;
    private PlayerMovement _move;
    private Rigidbody _rigid;

    private float rps;
    private int PowerShake;

    private void Awake()
    {
        _input = GetComponent<InputAgent>();
        _rigid = GetComponent<Rigidbody>();
        _move = GetComponent<PlayerMovement>();

        rps = _move._rollingPlayerSpeed;
    }

    private void Update()
    {
        if(_input.IsRolling)
        PlayerPowerRolling();
    }

    public void CamPos(Vector3 vec)
    {
        dir = vec;
    }

    private void PlayerPowerRolling()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _currentPowerSpeed += _chargeSpeed * Time.deltaTime;
            _currentPowerSpeed = Mathf.Clamp(_currentPowerSpeed, 0f, _maxPower);
            PowerShake = (int)_currentPowerSpeed;
            CameraManager.Instance.CamShake(PowerShake);
            _move._rollingPlayerSpeed = 0;
            _move.moveAble = false;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            _move._rollingPlayerSpeed = rps;
            CameraManager.Instance.CamShake(0);
            _currentPower = _currentPowerSpeed;
            Fire();
        }
    }
    private void Fire()
    {
        _rigid.velocity = Vector2.zero; //지금속도 초기화후에 
        _rigid.AddForce(dir * _currentPowerSpeed, ForceMode.Impulse);
        _currentPowerSpeed = 0;
        _currentPowerSpeed -= Time.deltaTime;
        StartCoroutine(FireCo());
    }

    private IEnumerator FireCo()
    {
        yield return new WaitForSeconds(0.3f);
        _move.moveAble = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9 && _currentPower > 0)
        {
            int addForce;
            if (_currentPower == _maxPower)
            {
                addForce = 20;
            }
            else
            {
                addForce = 10;
            }
            if (collision.collider.TryGetComponent(out IDamageable health))
            {
                Debug.Log(collision.collider);
                health.OnDamage((int)_currentPower * addForce);
                _currentPower = 0;
            }
        }
    }
}
