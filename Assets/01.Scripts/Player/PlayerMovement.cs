using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public float _normalPlayerSpeed;
    public float _rollingPlayerSpeed;

    private Rigidbody _rigid;
    private PlayerAnimationHash _anim;
    private InputAgent _inputAg;
    private CinemachineBasicMultiChannelPerlin _bPerinsNoise;

    public bool moveAble { get; set; } = true;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
        _anim = transform.Find("Visual").GetComponent<PlayerAnimationHash>();
        _inputAg = GetComponent<InputAgent>();

        var Cam = GameObject.Find("FollowCam").GetComponent<CinemachineVirtualCamera>();

        _bPerinsNoise = Cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    #region 플레이어 롤링
    private void PlayerRolling()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(!_anim.GetRollAnim())
            {
                _anim.SetRollAnim(true);
                StartCoroutine(StartRoll());
                CameraManager.Instance.CamShake(1f);
            }
            else
            {
                _anim.SetRollAnim(false);
                _inputAg.IsRolling = false;
            }
        }

    }

    private IEnumerator StartRoll()
    {
        yield return new WaitForSeconds(0.8f);
        _inputAg.IsRolling = true;
    }
    #endregion

    //플레이어 움직임(키보드 dir)
    public void PlayerWalk(Vector3 dir, bool IsRolling)
    {

        if (!moveAble) return;

        var vec = dir.normalized;


        if (IsRolling == false)
        {
            vec = vec * _normalPlayerSpeed;
            vec.y = _rigid.velocity.y;
            _rigid.velocity = vec;
            _anim.WalkAnim(dir != Vector3.zero);
        }
        else if (IsRolling == true)
        {
            vec = vec * _rollingPlayerSpeed;
            vec.y = _rigid.velocity.y;
            _rigid.velocity = vec;
        }

        CamShake(IsRolling);
        PlayerRolling();
    }

    //플레이어 로테이션(마우스 방향dir)
    public void PlayerRotate(Vector3 dir)
    {
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
    }
    private void CamShake(bool IsRolling)
    {
        if (IsRolling)
            _bPerinsNoise.m_AmplitudeGain = 0.5f;
        else
        _bPerinsNoise.m_AmplitudeGain = 0;
    }
}
