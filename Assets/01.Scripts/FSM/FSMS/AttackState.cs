using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : FSMState
{
    private NavMeshAgent agent;
    private bool isAtkCool = false;
    public bool isAtkAnimePlay { get; private set; } = false;
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public override void Setting(FSMController controller)
    {

        base.Setting(controller);

        agent = controller.GetComponent<NavMeshAgent>();

    }

    public override void OnEnterState()
    {

        agent.isStopped = true;
        agent.SetDestination(transform.position);

    }

    public override void OnExitState()
    {

        agent.isStopped = false;

    }

    public override void OnUpdateState()
    {

        if (isAtkCool || isAtkAnimePlay) return;

        StartCoroutine(AttackAnimeCo());

    }

    public void SetIsAnime(bool value)
    {

        isAtkAnimePlay = value;

    }

    private IEnumerator AttackAnimeCo()
    {

        isAtkAnimePlay = true;
        Debug.Log(123);
        yield return new WaitForSeconds(1f);

        isAtkAnimePlay = false;

        StartCoroutine(AttaceCoolDownEvent());

    }

    private IEnumerator AttaceCoolDownEvent()
    {

        isAtkCool = true;

        yield return new WaitForSeconds(1f);

        isAtkCool = false;

    }
}
