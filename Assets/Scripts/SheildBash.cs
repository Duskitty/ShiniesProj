using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SheildBash : MonoBehaviour
{
    private bool isPressingButton = false;
    public GameObject player;
    private float speed = 650f;
    private float buttonSpeed = 100f;
    public Rigidbody2D controller;
    public static bool isSheildBashing = false;
    private bool hasPressedBar = false;//checking if space bar has been pressed bar more than once to prevent double pressing
    private Vector2 notMovingPositive;
    private Vector2 notMovingNegative;

    private void Start()
    {
        controller = this.GetComponent<Rigidbody2D>();
        notMovingPositive = new Vector2(0.1f, 0.1f);
        notMovingNegative = new Vector2(-0.1f, 0.1f);
    }
    void Update()
    {
        //Debug.Log(isSheildBashing);
        /*
        if (isSheildBashing==true&&pickUpMirror.hasSheild == true && hasPressedBar == true && GetComponent<PlayerMovement>().enabled == false)
        {
            RestoreMovment();
 
        }
        if (isSheildBashing == true && pickUpMirror.hasSheild == true && GetComponent<PlayerMovement>().enabled == false)
        {
            RestoreMovment();
 
        }*/
        //{

        bool movingPositive = true;
        bool movingNegative = true;

        if (controller.velocity.x < notMovingPositive.x && controller.velocity.y < notMovingPositive.y)
        {
            movingPositive = false;
        }

        if (controller.velocity.x > notMovingNegative.x && controller.velocity.y > notMovingNegative.y)
        {
            movingNegative = false;
        }

        if (movingNegative == false && movingPositive == false)
        {
            //player is not moving
            RestoreMovment();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

            RestoreMovment();
        }
        // Debug.Log(pickUpMirror.hasSheild);
        if (Input.GetKey(KeyCode.LeftAlt) && pickUpMirror.hasSheild == true && hasPressedBar == false)
        {
            player.GetComponent<PlayerMovement>().enabled = false;//disable player input
                                                                  // GameObject.Find("DPadController").GetComponent<SetDPad>().DisablePad();

            isSheildBashing = true;
            hasPressedBar = true;
            PlayerDirection();


        }


        //}
    }
    public void PlayerDirection()
    {//figure out what way the player is facing then apply the right force
        Debug.Log("PLAYER DIRECTION CALLED");
        Debug.Log("Left:" + PlayerMovement.isMovingLeft);
        Debug.Log("Right:" + PlayerMovement.isMovingRight);
        Debug.Log("Up:" + PlayerMovement.isMovingUp);
        Debug.Log("Down:" + PlayerMovement.isMovingDown);

        if (PlayerMovement.isMovingLeft)
        {
            controller.AddForce(new Vector2(-speed, 0f), ForceMode2D.Force);
        }
        if (PlayerMovement.isMovingRight)
        {
            controller.AddForce(new Vector2(speed, 0f), ForceMode2D.Force);


        }
        if (PlayerMovement.isMovingUp)
        {
            controller.AddForce(new Vector2(0f, speed), ForceMode2D.Force);

        }
        if (PlayerMovement.isMovingDown)
        {
            controller.AddForce(new Vector2(0f, -speed), ForceMode2D.Force);


        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Boss"))
        {
            TestBoss1();
            RestoreMovment();
        }
        if (col.gameObject.CompareTag("enemy") || col.gameObject.CompareTag("bridge"))
        {
            //do nothing else statment is to pervent sticking to things

        }
        else if (col.gameObject.CompareTag("Cactus") || col.gameObject.CompareTag("rock") || col.gameObject.CompareTag("orb") || col.gameObject.CompareTag("sunbeam") || col.gameObject.CompareTag("mirage") || col.gameObject.CompareTag("Boss3") || col.gameObject.CompareTag("button") || col.gameObject.CompareTag("sign") || col.gameObject.CompareTag("Torch"))
        {
            RestoreMovment();

        }
        else if (col.gameObject.name == "RockBug" || col.gameObject.CompareTag("stairs"))
        {
            RestoreMovment();
        }
        else if (col.gameObject.CompareTag("break rock"))
        {
            RestoreMovment();
            RockSmash.charge = true;
        }
        else
        {
            RestoreMovment();
        }





    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("bridge"))
        //{

        RestoreMovment();
        //}

    }
    public void RestoreMovment()
    {

        controller.velocity = Vector2.zero;//remove the forces of the sheild bash
        player.GetComponent<PlayerMovement>().enabled = true;//enable player movment again
        isSheildBashing = false;
        hasPressedBar = false;
        isPressingButton = false;


    }
    public void AttackButton()
    {
        if (SceneManager.GetActiveScene().name == "World 2 P2")
        {
            //Debug.Log("Return");
            return;

        }
        else if (pickUpMirror.hasSheild == true && hasPressedBar == false)
        {
            player.GetComponent<PlayerMovement>().enabled = false;//disable player input
            isSheildBashing = true;
            hasPressedBar = true;
            isPressingButton = true;
            // Debug.Log("Pressed the button");

            StartCoroutine(TimeOfButton());


        }
    }


    public void TestBoss1()
    {
        if (isSheildBashing == true)
        {
            Debug.Log("boss took damage");
            B1Script.health--;
            GameObject.FindGameObjectWithTag("HealthBar").transform.localScale = new Vector3((B1Script.health / 10.0f), 1f, 1f);
            //RestoreMovment();
            if (B1Script.health <= 0)
            {
                GameObject.Find("Controller").SetActive(false);
                SpawnChargeGem.deadBoss = true;
            }
        }
        else if (B1Script.invin > 0)
        {
            Debug.Log("no damage");
            //no damage taken
        }
        else
        {
            B1Script.invin = 1f;
            Debug.Log("damage");
            // no shield bash = 1 less heart
            GameControlScript.health -= 1;
            print(GameControlScript.health);
            //print(col.name);
            //StartCoroutine(col.GetComponent<KnockBack>().KnockCo());
        }
    }
    public IEnumerator TimeOfButton()
    {
        int timer = 0;
        while (timer <= 10)
        {
            ButtonDirection();
            ++timer;
            yield return new WaitForSeconds(.02f);

        }
    }
    public void ButtonDirection() {

        if (PlayerMovement.isMovingLeft)
        {
            controller.AddForce(new Vector2(-buttonSpeed, 0f), ForceMode2D.Force);
        }
        if (PlayerMovement.isMovingRight)
        {
            controller.AddForce(new Vector2(buttonSpeed, 0f), ForceMode2D.Force);


        }
        if (PlayerMovement.isMovingUp)
        {
            controller.AddForce(new Vector2(0f, buttonSpeed), ForceMode2D.Force);

        }
        if (PlayerMovement.isMovingDown)
        {
            controller.AddForce(new Vector2(0f, buttonSpeed), ForceMode2D.Force);


        }


    }
}