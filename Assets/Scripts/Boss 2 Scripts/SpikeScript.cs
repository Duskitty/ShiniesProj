using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public GameObject self;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("made it inside spike script");
            if (B2Script.invin > 0)
            {
                Debug.Log("no damage");
                //no damage taken
            }
            else
            {
                B2Script.invin = 1f;
                Debug.Log("damage");
                // no shield bash = 1 less heart
                GameControlScript.health -= 1;
                print(GameControlScript.health);
                print(col.name);
            }
            Destroy(self);
        }
        else
        {
            Debug.Log("poo");
            Destroy(self);
        }
    }
}
