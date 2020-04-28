using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class B2StartTrack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        B2Script.fightBegin = true;
        B2Script.startTrack = true;
        B2ArmCheck.startTrack = true;
    }
}
