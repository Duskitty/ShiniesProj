using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeGemPickup : MonoBehaviour
{
    public GameObject chargeGem1;
    private void Start()
    {
        chargeGem1.gameObject.SetActive(false);

    }
    public void DeadBoss()
    {
        if (B1Script.health == 0)
        {
            chargeGem1.gameObject.SetActive(true);
        }
    }

    public void OnCollisionEnter2D(Collision2D thing)
    {
        Debug.Log("Picked up Charged Gem!");
        Destroy(GameObject.Find("chargeGem1"));

    }
}
