using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerHit : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        B1Script.hit = true;
    }
}
