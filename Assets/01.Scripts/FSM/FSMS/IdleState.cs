using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : FSMState
{
    private NavMeshAgent agent;

    public override void Setting(FSMController controller)
    {

        base.Setting(controller);

        agent = controller.GetComponent<NavMeshAgent>();

    }

    public override void OnEnterState()
    {

        agent.SetDestination(transform.position);
        agent.isStopped = true;

    }

    public override void OnExitState()
    {

        agent.isStopped = false;

    }

    public override void OnUpdateState()
    {



    }
}
