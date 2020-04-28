using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2ArmCheck : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (SheildBash.isSheildBashing == true) // TODO: change this to fire damage
            {
                Debug.Log("boss took damage");
                B2Script.health--;
                GameObject.FindGameObjectWithTag("HealthBar").transform.localScale = new Vector3((B2Script.health / 12.0f), 1f, 1f);
                GameObject.Find("Player").GetComponent<SheildBash>().RestoreMovment();
                if (B2Script.health == 0)
                {
                    GameObject.Find("Controller").SetActive(false);
                }
            }
            else if (B2Script.invin > 0) // TODO: add stun functionality to boss
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
