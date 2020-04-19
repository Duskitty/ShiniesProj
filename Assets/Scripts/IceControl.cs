using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceControl : MonoBehaviour
{
    GameObject player;
    Rigidbody2D controller;
    private bool isOnIce;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            IceMove();
        }
    }
    // Update is called once per frame
   
    void IceMove()
    {
        float speed = 10f;
        
        if (PlayerMovement.isMovingLeft)
        {
            controller.AddForce(new Vector2(-speed, 0f));
        }
        if (PlayerMovement.isMovingRight)
        {
            controller.AddForce(new Vector2(speed, 0f));


        }
        if (PlayerMovement.isMovingUp)
        {
            controller.AddForce(new Vector2(0f, speed));

        }
        if (PlayerMovement.isMovingDown)
        {
            controller.AddForce(new Vector2(0f, -speed));


        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<SheildBash>().enabled = true;
    }
}
