using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2LegCheck : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
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
                StartCoroutine(col.GetComponent<KnockBack>().KnockCo());
            }
        }
    }
}
