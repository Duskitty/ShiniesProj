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
    
    // Update is called once per frame
   
    void IceMove()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<SheildBash>().enabled = false;
        float speed = 20f;
        
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
        isOnIce = false;
        controller.velocity = Vector2.zero;
    }
    void SetOnIce(bool isOnIce) {
        this.isOnIce = isOnIce;
    }
    private void Update()
    {
        if (isOnIce) {
            IceMove();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        IceMove();

    }
}
