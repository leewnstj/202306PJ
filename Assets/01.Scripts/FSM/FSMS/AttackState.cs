using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : FSMState
{
    private NavMeshAgent agent;
    [SerializeField] private int Damage;
    public bool isAtkAnimePlay { get; private set; } = false;
    public override void Setting(FSMController controller)
    {

        base.Setting(controller);

        agent = controller.GetComponent<NavMeshAgent>();

    }

    public override void OnEnterState()
    {

        agent.isStopped = true;
        agent.SetDestination(transform.position);
        _anim.AttackAnimation(true);

    }

    public override void OnExitState()
    {

        agent.isStopped = false;
        _anim.AttackAnimation(false);

    }

    public override void OnUpdateState()
    {
        
    }

    public void SetIsAnime()
    {

        _playerHP.OnDamage(Damage);

    }
}
