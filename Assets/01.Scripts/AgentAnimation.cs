using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentAnimation : MonoBehaviour
{
    private readonly int _idleAnim = Animator.StringToHash("isIdle");
    private readonly int _walkAnim = Animator.StringToHash("isWalk");
    private readonly int _attackAnim = Animator.StringToHash("isAttack");
    private readonly int _deadAnim = Animator.StringToHash("isDead");

    public UnityEvent OnAnimationEnd;
    public UnityEvent OnAnimatioEvent;

    private Animator _anim;
    public Animator Anim => _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void WalkAnimation(bool value)
    {
        _anim.SetBool(_walkAnim, value);
    }

    public void IdleAnimation(bool value)
    {
        _anim.SetBool(_idleAnim, value);
    }

    public void AttackAnimation(bool value) 
    { 
        _anim.SetBool(_attackAnim, value);
    }

    public void DeadAnimation()
    {
        _anim.SetTrigger(_deadAnim);
        OnAnimationEnd?.Invoke();
    }

    public void OnAttackEvent()
    {
        OnAnimatioEvent?.Invoke();
    }
}
