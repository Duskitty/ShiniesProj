using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpMirror : MonoBehaviour
{
  public void OnCollisionEnter2D(Collision2D thing)
  {
    Debug.Log("Picked Up the mirror!");
    //Change player sprite here
    //GameObject.Find("Player").GetComponent<PlayerMovement>().animator.SetBool("HasShield", true);
    this.GetComponent<Renderer>().enabled = false;
  }
}
