using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase
{
    public virtual void OnStateEnter(object o = null)
    {

    }

    public virtual void OnStateStay(object o = null)
    {

    }

    public virtual void OnStateExit()
    {

    }
}

public class StatePlaying : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        MoveBall m = (MoveBall)o;

        GameManager.Instance.StartGame();
    }
}
public class StateReset : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        GameManager.Instance.ResetBall();
    }
}
public class StateEnd : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        GameManager.Instance.ShowMenu();
        GameManager.Instance.ResetPlayers();
    }
}
