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
    public Rigidbody2D controller;
    public static bool isSheildBashing = false;
    private bool hasPressedBar = false;//checking if space bar has been pressed bar more than once to prevent double pressing
    void Update()
    {
        horzMov = Input.GetAxis("Horizontal");
        verticalMov = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.Space) && pickUpMirror.hasSheild == true && hasPressedBar == false)
        {
            player.GetComponent<PlayerMovement>().enabled = false;//disable player input
            isSheildBashing = true;
            hasPressedBar = true;
            PlayerDirection();


        }


    }
    public void PlayerDirection()
    {//figure out what way the player is facing then apply the right force
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
        if (verticalMov < 0)
        {
            controller.AddForce(new Vector2(0f, -speed));


        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("enemy") || col.gameObject.CompareTag("bridge"))
        {
            //do nothing else statment is to pervent sticking to things

        }
        else if (col.gameObject.CompareTag("Cactus") || col.gameObject.CompareTag("rock") || col.gameObject.CompareTag("orb") || col.gameObject.CompareTag("sunbeam") || col.gameObject.CompareTag("mirage"))
        {
            RestoreMovment();
        }
        else {//for other things without a tag
            RestoreMovment();

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bridge"))
        {

            RestoreMovment();
        }
    }
    public void RestoreMovment()
    {
        controller.velocity = Vector2.zero;//remove the forces of the sheild bash
        player.GetComponent<PlayerMovement>().enabled = true;//enable player movment again
        isSheildBashing = false;
        hasPressedBar = false;

    }
    public void AttackButton()
    {
        if (pickUpMirror.hasSheild == true && hasPressedBar==false)
        {
            player.GetComponent<PlayerMovement>().enabled = false;//disable player input
            isSheildBashing = true;
            hasPressedBar = true;
            PlayerDirection();


        }
    }
   
}

