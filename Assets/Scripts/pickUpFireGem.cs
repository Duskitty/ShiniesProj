using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpFireGem : MonoBehaviour
{
    public GameObject fireGem;
  public void OnCollisionEnter2D(Collision2D thing)
  {
    Destroy(GameObject.Find("FireGem"));
        fireGem.gameObject.SetActive(true);

  }
}
