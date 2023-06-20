using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMDecision : MonoBehaviour
{
    public string nextState;
    protected Transform target;

    public abstract bool StartDecision();
}
