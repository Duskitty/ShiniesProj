using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class B1StartTrack : MonoBehaviour
{
    public static bool fightBegin = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject.FindGameObjectWithTag("Boss").GetComponent<AIPath>().enabled = true;
        GameObject.FindGameObjectWithTag("Boss").GetComponent<AIDestinationSetter>().enabled = true;
        fightBegin = true;
    }
}
