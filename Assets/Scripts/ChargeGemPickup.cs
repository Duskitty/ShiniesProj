﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeGemPickup : MonoBehaviour
{
    public GameObject chargeGem1, gameCharge,transition;
    private void Start()
    {
        chargeGem1.gameObject.SetActive(false);
        //GameObject.charge.GetComponent<BoxCollider2D>().enabled = false;
        gameCharge.GetComponent<BoxCollider2D>().enabled = false;
        transition.gameObject.GetComponent<BoxCollider2D>().enabled = false;

    }
    public void DeadBoss()
    {
        if (B1Script.health == 0)
        {
            gameCharge.GetComponent<BoxCollider2D>().enabled = true;
           chargeGem1.gameObject.SetActive(true);
            transition.gameObject.GetComponent<BoxCollider2D>().enabled = true;
           // GameObject.FindWithTag("charge").GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D thing)
    {
        Debug.Log("Picked up Charged Gem!");
        Destroy(GameObject.Find("chargeGem1"));

    }
}
