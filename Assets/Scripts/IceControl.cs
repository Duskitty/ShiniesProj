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
        GameObject.Find("DPadController").GetComponent<SetDPad>().DisablePad();

        float speed = 15f;
        
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
     //   RestoreMovment();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
       /* player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<SheildBash>().enabled = true;
        isOnIce = false;
        controller.velocity = Vector2.zero;
        //this.GetComponent<Collider2D>().enabled = false;*/
    }
   
  
    private void OnTriggerStay2D(Collider2D collision)

    {
        this.GetComponent<Collider2D>().enabled = true;

        IceMove();

    }
    void RestoreMovment() {

        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<SheildBash>().enabled = true;
        controller.velocity = Vector2.zero;
        GameObject.Find("DPadController").GetComponent<SetDPad>().EnablePad();


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IceMove();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        RestoreMovment();
    }

}
