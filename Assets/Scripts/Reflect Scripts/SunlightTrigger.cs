using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunlightTrigger : MonoBehaviour
{
    public bool inSunlight;
    private LineRenderer lightSpawn;

    public void Start()
    {
        lightSpawn = GameObject.Find("lightSpawn").GetComponent<LineRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D thing)
    {
        if(thing.tag == "Player")
        {
            inSunlight = true;
            lightSpawn.enabled = true;
            //Debug.Log("In sun");
        }

    }

    public void OnTriggerExit2D(Collider2D thing)
    {
        if (thing.tag == "Player")
        {
            inSunlight = false;
            lightSpawn.enabled = false;
            //Debug.Log("Not in sun");
        }
    }
}
