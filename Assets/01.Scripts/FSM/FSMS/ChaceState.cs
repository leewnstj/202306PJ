using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaceState : FSMState
{
    [SerializeField] private Transform target;

    private NavMeshAgent agent;

    public override void Setting(FSMController controller)
    {

        base.Setting(controller);

        agent = controller.GetComponent<NavMeshAgent>();

    }

    public override void OnEnterState()
    {

        agent.isStopped = false;

        _anim.WalkAnimation(true);

    }

    public override void OnExitState()
    {

        agent.isStopped = true;

        _anim.WalkAnimation(false);
    }

    public override void OnUpdateState()
    {

        agent.SetDestination(target.position);

    }
}
