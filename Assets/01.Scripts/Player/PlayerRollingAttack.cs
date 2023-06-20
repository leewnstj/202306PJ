using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollingAttack : MonoBehaviour
{
    private Rigidbody _rigid;
    [SerializeField] private float _chargeSpeed;
    [SerializeField] private float _maxPower;
    private float _currentPower;

    public Vector3 dir;

    private InputAgent _input;
    private PlayerMovement _move;
    private CinemachineBasicMultiChannelPerlin _bPerinsNoise;

    private float rps;
    private int PowerShake;

    private void Awake()
    {
        _input = GetComponent<InputAgent>();
        _rigid = GetComponent<Rigidbody>();
        _move = GetComponent<PlayerMovement>();

        var Cam = GameObject.Find("FollowCam").GetComponent<CinemachineVirtualCamera>();
        _bPerinsNoise = Cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

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
            PowerShake = (int)_currentPower;
            CameraManager.Instance.CamShake(PowerShake);
            _move._rollingPlayerSpeed = 0;
            _move.moveAble = false;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            _move._rollingPlayerSpeed = rps;
            CameraManager.Instance.CamShake(0);

            Fire();
        }
    }
    private void Fire()
    {
        _rigid.velocity = Vector2.zero; //지금속도 초기화후에 
        _rigid.AddForce(dir * _currentPower, ForceMode.Impulse);
        _currentPower = 0;
        StartCoroutine(FireCo());
    }

    private IEnumerator FireCo()
    {

        yield return new WaitForSeconds(0.3f);
        _move.moveAble = true;

    }

}
