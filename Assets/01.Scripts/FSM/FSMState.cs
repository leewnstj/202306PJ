using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState : MonoBehaviour
{
    protected FSMTransition transition;
    protected FSMController controller;

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