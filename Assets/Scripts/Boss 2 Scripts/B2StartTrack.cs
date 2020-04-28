using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class B2StartTrack : MonoBehaviour
{
    public static bool fightBegin = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject.FindGameObjectWithTag("Boss2").GetComponent<AIPath>().enabled = true;
        GameObject.FindGameObjectWithTag("Boss2").GetComponent<AIDestinationSetter>().enabled = true;
        fightBegin = true;
    }
}
