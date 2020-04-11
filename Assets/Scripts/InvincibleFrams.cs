using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleFrams : MonoBehaviour
{



    private bool invincible = false;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!invincible)
        {

            if (col.gameObject.CompareTag("Cactus"))
            {
                invincible = true;

                StartCoroutine(Invincible());

            }

        }
    }
    public IEnumerator Invincible()
    {
        yield return new WaitForSeconds(60);//changing the time allows for more invincible
        invincible = false;

    }
}
     
     
     
     
     
