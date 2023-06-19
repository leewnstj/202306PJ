using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMDecision : MonoBehaviour
{
    public string nextState;

    public abstract bool StartDecision();
}
