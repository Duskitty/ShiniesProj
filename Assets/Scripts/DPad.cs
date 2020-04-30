using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPad : MonoBehaviour
{
    private bool isUsingDPad = false;
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
        }
        else {
            isUsingDPad = false;
        }
    }
   public void Up()
    {
        if (isUsingDPad)
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
        }
    }
    public void Down()
    {
        transform.Translate(new Vector3(0f, -speed * Time.deltaTime, 0f));
        animator.SetBool("isDown", true);
        animator.SetBool("isRight", false);
        animator.SetBool("isLeft", false);
        animator.SetBool("isUp", false);
        animator.SetBool("isMoving", true);

       PlayerMovement. isMovingUp = false;
        PlayerMovement.isMovingDown = true;
       PlayerMovement. isMovingLeft = false;
       PlayerMovement. isMovingRight = false;
    }
    public void Right() {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0f, 0f));


        animator.SetBool("isRight", true);
        animator.SetBool("isLeft", false);
        animator.SetBool("isDown", false);
        animator.SetBool("isUp", false);
        animator.SetBool("isMoving", true);

      PlayerMovement.  isMovingUp = false;
       PlayerMovement .isMovingDown = false;
       PlayerMovement. isMovingLeft = false;
      PlayerMovement.  isMovingRight = true;
    }
    public void Left() {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0f, 0f));

        animator.SetBool("isLeft", true);
        animator.SetBool("isRight", false);
        animator.SetBool("isDown", false);
        animator.SetBool("isUp", false);
        animator.SetBool("isMoving", true);

       PlayerMovement. isMovingUp = false;
      PlayerMovement.  isMovingDown = false;
      PlayerMovement.  isMovingLeft = true;
      PlayerMovement.  isMovingRight = false;
    }
}

