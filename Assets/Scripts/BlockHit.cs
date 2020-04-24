using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHit : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Rigidbody2D controller;
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision.gameObject.name);
            GameObject.Find("IceTilemap").GetComponent<IceControl>().enabled = false;
            GameObject.Find("IceTilemap").GetComponent<Collider2D>().enabled = false;


            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<SheildBash>().enabled = true;
            // isOnIce = false;
            controller.velocity = Vector2.zero;
            
           // GameObject.Find("IceTilemap").GetComponent<IceControl>().enabled = false;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Left the block");

        GameObject.Find("IceTilemap").GetComponent<IceControl>().enabled = true;
        GameObject.Find("IceTilemap").GetComponent<Collider2D>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<SheildBash>().enabled = false;


    }

      private void OnTriggerEnter2D(Collider2D col)
      {
        if (col.name == "Player")
        {
          //Debug.Log(collision.gameObject.name);
          GameObject.Find("IceTilemap").GetComponent<IceControl>().enabled = false;
          GameObject.Find("IceTilemap").GetComponent<Collider2D>().enabled = false;


          player.GetComponent<PlayerMovement>().enabled = true;
          player.GetComponent<SheildBash>().enabled = true;
          // isOnIce = false;
          controller.velocity = Vector2.zero;
        }
      }

  private void OnTriggerExit2D(Collider2D col)
  {
    if (col.name == "Player")
    {
      //Debug.Log(collision.gameObject.name);
      GameObject.Find("IceTilemap").GetComponent<IceControl>().enabled = true;
      GameObject.Find("IceTilemap").GetComponent<Collider2D>().enabled = true;


      player.GetComponent<PlayerMovement>().enabled = false;
      player.GetComponent<SheildBash>().enabled = false; ;
      // isOnIce = false;
      //controller.velocity = Vector2.zero;
    }
  }

}

