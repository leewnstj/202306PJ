using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHash : MonoBehaviour
{
    private readonly int PlayerWalk = Animator.StringToHash("Walk_Anim");
    private readonly int PlayerRoll = Animator.StringToHash("Roll_Anim");
    private readonly int PlayerOpen = Animator.StringToHash("Open_Anim");

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    
    public void WalkAnim(bool value)
    {
        _anim.SetBool(PlayerWalk, value);
    }

    public void SetRollAnim(bool value)
    {
        _anim.SetBool(PlayerRoll, value);
    }

    public bool GetRollAnim()
    {
        return _anim.GetBool(PlayerRoll);
    }

    public void OpenAnim(bool value)
    {
        _anim.SetBool(PlayerOpen, value);
    }
}
