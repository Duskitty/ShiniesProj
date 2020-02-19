using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float thrust;
    public Rigidbody2D player;
    public GameObject badGuy;

    /*if (other.gameObject.tag=="enemy")
        {


            player.isKinematic = false;
            Vector2 difference = (player.transform.position - transform.position);
            difference = difference.normalized * thrust;
            player.AddForce(difference, ForceMode2D.Impulse);
            player.isKinematic = true;
        }
    }*/
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy") {
            Debug.Log("Hit");
            player.isKinematic = false;
            Vector2 difference = (player.transform.position - badGuy.transform.position);
            difference = difference.normalized * thrust;
            player.AddForce(difference, ForceMode2D.Impulse);
            player.isKinematic = true;
        }

    }
   
}


