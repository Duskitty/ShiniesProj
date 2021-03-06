﻿using UnityEngine;

[System.Serializable]
public class PlayerMovement : MonoBehaviour
    //1 is up, 2 is down, 3 is left and 4 is right
{
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    public Animator animator;
    public float speed = 0f;
    public Animator textBoxAnimator;
    public Rigidbody2D player;
    public bool bridgeSafe = false;
    // Update is called once per frame
    void FixedUpdate()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        verticalMove = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        //animator.SetFloat("Speed", Mathf.Abs(verticalMove));
        if (textBoxAnimator.GetBool("isOpen"))
        {
            return;

        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0f, speed * Time.deltaTime, 0f));
            animator.SetBool("isUp", true);
            animator.SetBool("isDown", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0f, -speed * Time.deltaTime, 0f));
            animator.SetBool("isDown", true);
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isUp", false);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0f, 0f));
            
             animator.SetBool("isLeft", true);
            animator.SetBool("isRight", false);
            animator.SetBool("isDown", false);
            animator.SetBool("isUp", false);




        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0f, 0f));
           

                animator.SetBool("isRight", true);
                animator.SetBool("isLeft", false);
                 animator.SetBool("isDown", false);
                animator.SetBool("isUp", false);




        }
<<<<<<< HEAD
        if (!(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))) {//no input 
=======
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)) {//no input 
            if (isMovingUp == true) {
                animator.SetBool("isIdleUp", true);
                animator.SetBool("isIdleDown", false);
                animator.SetBool("isIdleRight", false);
                animator.SetBool("isIdleLeft", false);
             animator.SetBool("isMoving", false);
                animator.SetBool("isUp", false);
                Debug.Log("Not Moving Up");

            }
            if (isMovingDown == true) { 
            
            }
            if (isMovingLeft == true) {

                animator.SetBool("isIdleUp", false);
                animator.SetBool("isIdleDown", false);
                animator.SetBool("isIdleRight", false);
                animator.SetBool("isIdleLeft", true);
                animator.SetBool("isMoving", false);
                animator.SetBool("isUp", false);
                Debug.Log("Not Moving Left");

            }
            if (isMovingRight == true) {
                animator.SetBool("isIdleUp", false);
                animator.SetBool("isIdleDown", false);
                animator.SetBool("isIdleRight", true);
                animator.SetBool("isIdleLeft", false);
                animator.SetBool("isMoving", false);
                animator.SetBool("isUp", false);
                Debug.Log("Not Moving Right");


            }
            if (isMovingDown == true) {
                animator.SetBool("isIdleUp", false);
                animator.SetBool("isIdleDown", true);
                animator.SetBool("isIdleRight", false);
                animator.SetBool("isIdleLeft", false);
                animator.SetBool("isMoving", false);
                animator.SetBool("isUp", false);

            }
>>>>>>> parent of 273e7ac... animations good



        }
       
    }
}
