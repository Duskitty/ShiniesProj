using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSmash : MonoBehaviour
{
    public float rockDelay = 0f;
    public Animator animi;


    public void OnCollisionEnter2D(Collision2D col)
    {
        if (SheildBash.isSheildBashing==true  && pickUpMirror.hasSheild==true) { 
            
                animi.SetBool("Break", true);
                StartCoroutine(RockDie());



        }
    }

 
    public IEnumerator RockDie() {
        yield return new WaitForSeconds(rockDelay);
        Destroy(gameObject);
        animi.SetBool("Break", false);
        GameObject.Find("Player").GetComponent<SheildBash>().RestoreMovment();


    }
}
