using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpMirror : MonoBehaviour
{
  public void OnCollisionEnter2D(Collision2D thing)
  {
    Debug.Log("Picked Up the mirror!");
    //Change player sprite here
    this.GetComponent<BoxCollider2D>().enabled = false;
    this.GetComponent<SpriteRenderer>().enabled = false;
  }
}
