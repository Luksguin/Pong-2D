using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        MENU,
        PLAYING,
        RESTART,
        END,
    }

    private StateBase _currentstate;
    public static StateMachine Instance;

    public Dictionary<States, StateBase> dicionaryStates;

    private void Awake()
    {
        Instance = this;

        dicionaryStates = new Dictionary<States, StateBase>();
        dicionaryStates.Add(States.MENU, new StateBase());
        dicionaryStates.Add(States.PLAYING, new StatePlaying());
        dicionaryStates.Add(States.RESTART, new StateReset());
        dicionaryStates.Add(States.END, new StateEnd());

        SwitchStates(States.MENU);
    }

    public void SwitchStates(States state)
    {
        if (_currentstate != null) _currentstate.OnStateExit();

        _currentstate = dicionaryStates[state];

        if (_currentstate != null) _currentstate.OnStateEnter();
    }

    private void Update()
    {
        if (_currentstate != null) _currentstate.OnStateStay();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchStates(States.PLAYING);
        }
    }

    public void ResetPosition()
    {
        SwitchStates(States.RESTART);
    }
}
