using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceStop : MonoBehaviour
{
  GameObject player;

  void Start()
  {
    player = GameObject.Find("Player");
  }

  void OnCollisionEnter2D(Collision2D col)
  {
    if(col.collider.name == "Player")
    {
      GameObject.Find("IceTilemap").GetComponent<IceControl>().enabled = false;
      GameObject.Find("IceTilemap").GetComponent<Collider2D>().enabled = false;


      player.GetComponent<PlayerMovement>().enabled = true;
      player.GetComponent<SheildBash>().enabled = true;
      GetComponent<BoxCollider2D>().enabled = false;
    }
  }
}
