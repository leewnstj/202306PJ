using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDecision : FSMDecision
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform target;
    [SerializeField] private Color gizmoColor = Color.white;
    [SerializeField] private float range;

    private AttackState attackState;

    private void Awake()
    {

        attackState = transform.parent.GetComponent<AttackState>();

    }

    public override bool StartDecision()
    {

        var value = Physics.Raycast(transform.position, target.position - transform.position, out var hit, range, layerMask);

        if (hit.transform != null
            && !(hit.transform.gameObject.name == "Player")
            && !attackState.isAtkAnimePlay)
        {

            return true;

        }

        return !value && !attackState.isAtkAnimePlay;

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {

        var old = Gizmos.color;
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = old;

    }

#endif
}
