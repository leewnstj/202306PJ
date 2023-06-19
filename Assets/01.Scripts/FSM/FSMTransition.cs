using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMTransition : MonoBehaviour
{
    [SerializeField] private List<FSMDecision> decisions = new List<FSMDecision>();

    private FSMController controller;

    public void Setting(FSMController controller)
    {

        this.controller = controller;

    }

    public void ChackTransition()
    {

        foreach (var item in decisions)
        {

            if (item.StartDecision())
            {

                controller.ChangeState(item.nextState);
                break;

            }

        }

    }
}
