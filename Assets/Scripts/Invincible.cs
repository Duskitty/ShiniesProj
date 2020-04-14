using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : MonoBehaviour
{
    public static bool isHit = false;
    public float timeofInvincible = 2f;

    private bool invincible = false;


    private void Update()
    {
        if (isHit) {

            StartCoroutine(InvincibleTime());
        }
    }






    public IEnumerator InvincibleTime()
    {
        yield return new WaitForSeconds(timeofInvincible);//changing the time allows for more invincible
        isHit = false;

    }
}





/*private void OnCollisionEnter2D(Collision2D col)
    {
        if (!invincible)
        {

            if (col.gameObject.CompareTag("Cactus"))
            {
                invincible = true;

                StartCoroutine(Invincible());

            }

        }
    }*/
