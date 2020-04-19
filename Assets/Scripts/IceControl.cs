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
            isOnIce = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isOnIce) {
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<SheildBash>().enabled = false;
            IceMove();
        }
    }
    void IceMove()
    {
        float speed = controller.mass;//calucating the friction force 
        speed *= 9.81f;
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
    private void OnCollisionEnter2D(Collision collision)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<SheildBash>().enabled = false;
    }
}
