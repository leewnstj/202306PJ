using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState : MonoBehaviour
{
    protected FSMTransition transition;
    protected FSMController controller;
    protected AgentAnimation _anim;
    protected AgentHealth _playerHP;


    private void Awake()
    {
        _anim = transform.parent.parent.Find("Visual").GetComponent<AgentAnimation>();
        _playerHP = GameObject.Find("Player").GetComponent<AgentHealth>();
    }

    public virtual void Setting(FSMController controller)
    {

        transition = GetComponent<FSMTransition>();
        this.controller = controller;
        transition.Setting(controller);

    }

    public abstract void OnEnterState();
    public abstract void OnUpdateState();
    public abstract void OnExitState();
    public void ChackTransition()
    {

        transition.ChackTransition();

    }
}
