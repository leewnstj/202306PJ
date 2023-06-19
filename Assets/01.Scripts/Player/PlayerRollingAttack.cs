using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollingAttack : MonoBehaviour
{
    private Rigidbody _rigid;
    public float _currentPower;
    [SerializeField] private float _chargeSpeed;
    [SerializeField] private float _maxPower;

    public Vector3 dir;

    private InputAgent _input;
    private PlayerMovement _move;

    private float rps;

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
            _currentPower += _chargeSpeed * Time.deltaTime;
            _currentPower = Mathf.Clamp(_currentPower, 0f, _maxPower);
            _move._rollingPlayerSpeed = 0;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            _move._rollingPlayerSpeed = rps;
            Fire();
        }
    }
    private void Fire()
    {
        _rigid.velocity = Vector2.zero; //지금속도 초기화후에 
        _rigid.AddForce(dir * _currentPower, ForceMode.Impulse);
        _currentPower = 0;
    }
}
