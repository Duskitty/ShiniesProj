using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpChargedGem : MonoBehaviour
{
    public GameObject chargeGem1;
    private void Start()
    {
        chargeGem1.gameObject.SetActive(false);
        
    }
    public void OnCollisionEnter2D(Collision2D thing)
    {
        Debug.Log("Picked up Charged Gem!");
        Destroy(GameObject.Find("chargeGem1"));
        chargeGem1.gameObject.SetActive(true);

    }
}
