using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;
using Pathfinding;

public class B1NullState : State<B1Script>
{
    private static B1NullState _instance;

    private B1NullState()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }

    public static B1NullState Instance
    {
        get
        {
            if (_instance == null)
            {
                new B1NullState();
            }
            return _instance;
        }
    }

    public override void EnterState(B1Script _owner)
    {
        Debug.Log("entered null state");
    }

    public override void ExitState(B1Script _owner)
    {
        Debug.Log("exited null state");
    }

    public override void UpdateState(B1Script _owner)
    {
        
    }
}
