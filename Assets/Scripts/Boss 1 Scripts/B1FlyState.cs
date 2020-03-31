using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;
using Pathfinding;

public class B1FlyState : State<B1Script>
{
    private static B1FlyState _instance;
    public GameObject enemy;
    public GameObject clone;

    private B1FlyState()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }

    public static B1FlyState Instance
    {
        get
        {
            if (_instance == null)
            {
                new B1FlyState();
            }
            return _instance;
        }
    }

    public override void EnterState(B1Script _owner)
    {
        Debug.Log("entered fly");
        
    }

    public override void ExitState(B1Script _owner)
    {
        //GameObject.Find("BeedleBro").transform.localPosition = B1ChargeState.place.localPosition;
        //GameObject.Find("BeedleBro").transform.localRotation = B1ChargeState.place.localRotation;
        //GameObject.Find("Controller").GetComponent<AIPath>().enabled = true;
        //GameObject.Find("Controller").GetComponent<AIDestinationSetter>().enabled = true;
        Debug.Log("exited fly");
        
    }

    public override void UpdateState(B1Script _owner)
    {
        
    }
}
