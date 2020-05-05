using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        
        if (isSheildBashing==true&&pickUpMirror.hasSheild == true && hasPressedBar == true && GetComponent<PlayerMovement>().enabled == false)
        {
            RestoreMovment();

        }
        //{
            if (Input.GetKeyDown(KeyCode.Q))
            {

                RestoreMovment();
            }
            horzMov = Input.GetAxis("Horizontal");
            verticalMov = Input.GetAxis("Vertical");
            // Debug.Log(pickUpMirror.hasSheild);
            if (Input.GetKey(KeyCode.Space) && pickUpMirror.hasSheild == true && hasPressedBar == false)
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
            if(col.gameObject.CompareTag("Boss"))
            {
                TestBoss1();
                RestoreMovment();
            }
            if (col.gameObject.CompareTag("enemy") || col.gameObject.CompareTag("bridge")  )
            {
            //do nothing else statment is to pervent sticking to things

            }
            else if (col.gameObject.CompareTag("Cactus") || col.gameObject.CompareTag("rock") || col.gameObject.CompareTag("orb") || col.gameObject.CompareTag("sunbeam") || col.gameObject.CompareTag("mirage") ||col.gameObject.CompareTag("Boss3") || col.gameObject.CompareTag("button") || col.gameObject.CompareTag("sign") || col.gameObject.CompareTag("Torch"))
            {
                RestoreMovment();

            }
            else if (col.gameObject.name == "RockBug" || col.gameObject.CompareTag("stairs") || col.gameObject.CompareTag("break rock")) {
                RestoreMovment();
            }




            else
            {//for other things without a tag
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
            //  GameObject.Find("DPadController").GetComponent<SetDPad>().EnablePad();


        }
        public void AttackButton()
        {
            if (SceneManager.GetActiveScene().name == "World 2 P2")
            {
                return;

            }
            if (pickUpMirror.hasSheild == true && hasPressedBar == false)
            {
                player.GetComponent<PlayerMovement>().enabled = false;//disable player input
                isSheildBashing = true;
                hasPressedBar = true;
                //  GameObject.Find("DPadController").GetComponent<SetDPad>().DisablePad();
                PlayerDirection();


            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            RestoreMovment();
        }

    public void TestBoss1()
    {
        if (isSheildBashing == true)
        {
            Debug.Log("boss took damage");
            B1Script.health--;
            GameObject.FindGameObjectWithTag("HealthBar").transform.localScale = new Vector3((B1Script.health / 10.0f), 1f, 1f);
            GameObject.Find("Player").GetComponent<SheildBash>().RestoreMovment();
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

   
}

