using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildBash : MonoBehaviour
{
    public GameObject player;
    public float speed = 10f;
    private Vector3 dir;
    private float horzMov;
    private float verticalMov;
  public  Rigidbody2D controller;
    
    void Update()
    {
        horzMov = Input.GetAxis("Horizontal");
        verticalMov = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.Space)) {
            player.GetComponent<PlayerMovement>().enabled = false;//disable player input
            PlayerDirection();

           // player.GetComponent<PlayerMovement>().enabled = true;//enable player input





        }


    }
    public void PlayerDirection() {//figure out what way the player is facing then apply the right foce
        if (horzMov < 0)
        {
            controller.AddForce(new Vector2(-speed, 0f));
        }
         if (horzMov > 0)
        {
            controller.AddForce(new Vector2(speed, 0f));


        }
         if (verticalMov > 0)
        {
            controller.AddForce(new Vector2(0f, speed));

        }
         if (verticalMov < 0) {
            controller.AddForce(new Vector2(0f, -speed));


        }
    }
}
