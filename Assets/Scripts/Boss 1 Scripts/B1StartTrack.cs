using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class B1StartTrack : MonoBehaviour
{
    public static bool fightBegin = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject.Find("Controller").GetComponent<AIPath>().enabled = true;
        GameObject.Find("Controller").GetComponent<AIDestinationSetter>().enabled = true;
        fightBegin = true;
    }
}
