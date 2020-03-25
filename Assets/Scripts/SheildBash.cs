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
    public static bool isSheildBashing = false;
    private bool hasSpaceBeenPressed = false;//used to check if the space bar has been pressed more than once 
    void Update()
    {
        horzMov = Input.GetAxis("Horizontal");
        verticalMov = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.Space)&& pickUpMirror.hasSheild == true&&hasSpaceBeenPressed==false) {//last bool check is to see if they have pressed the space bar more than once 
            player.GetComponent<PlayerMovement>().enabled = false;//disable player input
            isSheildBashing = true;
            hasSpaceBeenPressed = true;
            PlayerDirection();






        }


    }
    public void PlayerDirection() {//figure out what way the player is facing then apply the right force
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BreakableRock" || collision.gameObject.name == "ShroomBoi_Exploder_0")
        {
            //do nothing

        }
        else {
            isSheildBashing = false;
            RestoreMovment();
        }
    }
    public  void RestoreMovment() {
        if (isSheildBashing == false) {
            player.GetComponent<PlayerMovement>().enabled = true;//enable player movment again
            controller.velocity = Vector2.zero;//remove the "sheild bash" force
            hasSpaceBeenPressed = false;
        }

    }
}
