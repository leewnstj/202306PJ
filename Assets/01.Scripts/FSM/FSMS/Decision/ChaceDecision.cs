using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaceDecision : FSMDecision
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Color gizmoColor = Color.white;
    [SerializeField] private float range;
    [SerializeField] private bool isInner;

    private void OnEnable()
    {

        target = FindObjectOfType<PlayerMovement>().transform;

    }

    public override bool StartDecision()
    {
        var value = Physics.Raycast(transform.position, target.position - transform.position, out var hit, range, layerMask);

        if (hit.transform != null)
        {
            return !(hit.collider.CompareTag("Player"));
        }

        return isInner ? value : !value;
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
