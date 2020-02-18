using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float thrust;
    public Rigidbody2D player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {


            player.isKinematic = false;
            Vector2 difference = (player.transform.position - transform.position);
            difference = difference.normalized * thrust;
            player.AddForce(difference, ForceMode2D.Impulse);
            player.isKinematic = true;
        }


    }
    }


