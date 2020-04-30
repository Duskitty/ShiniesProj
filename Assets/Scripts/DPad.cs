using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPad : MonoBehaviour
{
    private bool isUsingDPad = false;
    private bool isLeft = false;
    private bool isRight = false;
    private bool isUp = false;
    private bool isDown = false;
    public float speed = 3f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isUsingDPad = true;
            if (isUp) {
                transform.Translate(new Vector3(0f, speed * Time.deltaTime, 0f));
                animator.SetBool("isUp", true);
                animator.SetBool("isDown", false);
                animator.SetBool("isLeft", false);
                animator.SetBool("isRight", false);
                animator.SetBool("isMoving", true);

                PlayerMovement.isMovingUp = true;
                PlayerMovement.isMovingDown = false;
                PlayerMovement.isMovingLeft = false;
                PlayerMovement.isMovingRight = false;
            }
            if (isRight) {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0f, 0f));


                animator.SetBool("isRight", true);
                animator.SetBool("isLeft", false);
                animator.SetBool("isDown", false);
                animator.SetBool("isUp", false);
                animator.SetBool("isMoving", true);

                PlayerMovement.isMovingUp = false;
                PlayerMovement.isMovingDown = false;
                PlayerMovement.isMovingLeft = false;
                PlayerMovement.isMovingRight = true;
            }
        }
        else {
            isUsingDPad = false;
        }
        if (Input.GetMouseButtonUp(0)) {
            isUsingDPad = false;
            isUp = false;
            isLeft = false;
            isRight = false;
            isDown = false;

        }
    }
   public void Up()
    {
        isUp = true;
        isLeft = false;
        isRight = false;
        isDown = false;
    /* if (isUsingDPad)
     {
         transform.Translate(new Vector3(0f, speed * Time.deltaTime, 0f));
         animator.SetBool("isUp", true);
         animator.SetBool("isDown", false);
         animator.SetBool("isLeft", false);
         animator.SetBool("isRight", false);
         animator.SetBool("isMoving", true);

         PlayerMovement.isMovingUp = true;
         PlayerMovement.isMovingDown = false;
         PlayerMovement.isMovingLeft = false;
         PlayerMovement.isMovingRight = false;
     }*/
}
    public void Down()
    {
        isUp = false;
        isLeft = false;
        isRight = false;
        isDown = true;
        /* transform.Translate(new Vector3(0f, -speed * Time.deltaTime, 0f));
         animator.SetBool("isDown", true);
         animator.SetBool("isRight", false);
         animator.SetBool("isLeft", false);
         animator.SetBool("isUp", false);
         animator.SetBool("isMoving", true);

        PlayerMovement. isMovingUp = false;
         PlayerMovement.isMovingDown = true;
        PlayerMovement. isMovingLeft = false;
        PlayerMovement. isMovingRight = false;*/
    }
    public void Right() {
        isUp = false;
        isLeft = false;
        isRight = true;
        isDown = false;
        /*transform.Translate(new Vector3(speed * Time.deltaTime, 0f, 0f));


        animator.SetBool("isRight", true);
        animator.SetBool("isLeft", false);
        animator.SetBool("isDown", false);
        animator.SetBool("isUp", false);
        animator.SetBool("isMoving", true);

      PlayerMovement.  isMovingUp = false;
       PlayerMovement .isMovingDown = false;
       PlayerMovement. isMovingLeft = false;
      PlayerMovement.  isMovingRight = true;*/
    }
    public void Left() {
        isUp = false;
        isLeft = true;
        isRight = false;
        isDown = false;
        /* transform.Translate(new Vector3(-speed * Time.deltaTime, 0f, 0f));

         animator.SetBool("isLeft", true);
         animator.SetBool("isRight", false);
         animator.SetBool("isDown", false);
         animator.SetBool("isUp", false);
         animator.SetBool("isMoving", true);

        PlayerMovement. isMovingUp = false;
       PlayerMovement.  isMovingDown = false;
       PlayerMovement.  isMovingLeft = true;
       PlayerMovement.  isMovingRight = false;*/
    }
}

