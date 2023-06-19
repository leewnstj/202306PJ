using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMController : MonoBehaviour
{
    [SerializeField] private List<FSMStateControllClass> states = new List<FSMStateControllClass>();

    private FSMState currentState;

    private void Awake()
    {

        currentState = states[0].state;

        foreach (var item in states)
        {

            item.state.Setting(this);

        }

    }

    private void Start()
    {

        currentState.OnEnterState();

    }

    private void Update()
    {

        currentState.OnUpdateState();
        currentState.ChackTransition();

    }

    public void ChangeState(string value)
    {

        if (states.Find(x => x.stateName == value) != null)
        {

            var state = states.Find(x => x.stateName == value);

            currentState.OnExitState();
            currentState = state.state;
            currentState.OnEnterState();

        }

    }
}
