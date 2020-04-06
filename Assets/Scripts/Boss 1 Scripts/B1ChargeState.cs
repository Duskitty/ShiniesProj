using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;
using Pathfinding;

public class B1ChargeState : State<B1Script>
{
    private static B1ChargeState _instance;
    private int speed = 100;
    private float timer = 0f;
    private float stunLength = 3f;
    private bool oneStop = true;
    public static bool stunned = false;
    private Vector3 direction;
    public static Transform place;

    private B1ChargeState()
    {
        if(_instance != null)
        {
            return;
        }
        _instance = this;
    }

    public static B1ChargeState Instance
    {
        get
        {
            if(_instance == null)
            {
                new B1ChargeState();
            }
            return _instance;
        }
    }

    public override void EnterState(B1Script _owner)
    {
        Debug.Log("Entering Charge State");
        //disable pathfinding
        //charge in current direction at increased speed
        /*
        place = GameObject.Find("Controller").transform;
        GameObject.Find("Controller").GetComponent<AIPath>().enabled = false;
        GameObject.Find("Controller").GetComponent<AIDestinationSetter>().enabled = false;
        Vector3 dir = GameObject.Find("Controller").transform.position + GameObject.Find("Player").transform.position;
        direction = dir;
        GameObject.Find("BeedleBro").GetComponent<Rigidbody2D>().AddForce(direction);
        */

        GameObject.Find("Controller").GetComponent<AIPath>().maxSpeed = 3;
    }

    public override void ExitState(B1Script _owner)
    {
        Debug.Log("Exiting Charge State");
    }

    public override void UpdateState(B1Script _owner)
    {
        //check to see if boss hit a collider, if possible
        //if collider hit, turn bool true, which can be checked after stateMachine.Update(), which causes this state to be exited
        if(B1Script.hit == true)
        {
            stunned = true;
            if(oneStop == true)
            {
                GameObject.Find("Controller").GetComponent<AIPath>().maxSpeed = 0;
                oneStop = false;
            }
            timer += Time.deltaTime;
            if(timer >= stunLength)
            {
                timer = 0f;
                B1Script.chargeHit = true;
                oneStop = true;
                GameObject.Find("Controller").GetComponent<AIPath>().maxSpeed = 1;
            }
            
        }
    }
}
