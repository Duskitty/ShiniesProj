﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSmash : MonoBehaviour
{
    public float rockDelay = 0.5f;
    public Animator animi;
    public static bool charge = false;

    private void Update()
    {
        Debug.Log("is bashing is " + SheildBash.isSheildBashing);
       // Debug.Log("has sheild is" + pickUpMirror.hasSheild);
       if(charge == true)
        {
            charge = false;
            KillRock();
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (SheildBash.isSheildBashing==true ) { 
            
                animi.SetBool("Break", true);
                StartCoroutine(RockDie());



        }
    }

    public void KillRock()
    {
        animi.SetBool("Break", true);
        StartCoroutine(RockDie());
    }


    public IEnumerator RockDie() {
        yield return new WaitForSeconds(rockDelay);
        Destroy(gameObject);
     //   animi.SetBool("Break", false);
        GameObject.Find("Player").GetComponent<SheildBash>().RestoreMovment();


    }
}
