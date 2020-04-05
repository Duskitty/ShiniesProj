/*
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class JoyStickScript : MonoBehaviour
{
    public int speed = 8;
    // Start is called before the first frame update
    Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
 
 
 
    // Update is called once per frame
    void Update()
    {
 
    }
 
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
 
    }
 
 
} */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public float speed = 8.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    public GameObject player;
    public GameObject circle;
    public GameObject outerCircle;
    public int invertDirection = 1; //set this to -1 when animation is rotated to keep joystick working right.

    public Animator animator;
    //move variables for the animator 
    private bool isMovingUp = false;
    bool isMovingDown = false;
    bool isMovingRight = false;
    bool isMovingLeft = false;
    private void Start()
    {
        //I prefer to get values here instead of setting them in unity gui
        //either one works

        player = GameObject.Find("Player");
        circle = GameObject.Find("ContinueButton"); 
         outerCircle = GameObject.Find("D-Pad"); 
         animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

            circle.transform.position = pointA;
            outerCircle.transform.position = pointA;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        }
        else
        {
            touchStart = false;
        }

    }
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction);

            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);

            if (pointB.x > pointA.x && pointB.y > pointA.y) //top right quadrant
            {
                animator.SetBool("isRight", true);
                animator.SetBool("isLeft", false);
                animator.SetBool("isDown", false);
                animator.SetBool("isUp", false);
                animator.SetBool("isMoving", true);

                //checking for idle 
                isMovingUp = false;
                isMovingDown = false;
                isMovingLeft = false;
                isMovingRight = true;
            }
            else if (pointB.x < pointA.x && pointB.y > pointA.y) //top left quadrant
            {
                animator.SetBool("isLeft", true);
                animator.SetBool("isRight", false);
                animator.SetBool("isDown", false);
                animator.SetBool("isUp", false);
                animator.SetBool("isMoving", true);

                //checking for idle
                isMovingUp = false;
                isMovingDown = false;
                isMovingLeft = true;
                isMovingRight = false;

            }
            else if (pointB.x > pointA.x && pointB.y < pointA.y) //bottom right quadrant
            {
                animator.SetBool("isRight", true);
                animator.SetBool("isLeft", false);
                animator.SetBool("isDown", false);
                animator.SetBool("isUp", false);
                animator.SetBool("isMoving", true);
                //checking for idle
                isMovingUp = false;
                isMovingDown = false;
                isMovingLeft = false;
                isMovingRight = true;
            }
            else if (pointB.x < pointA.x && pointB.y < pointA.y) //bottom left quadrant
            {
                animator.SetBool("isLeft", true);
                animator.SetBool("isRight", false);
                animator.SetBool("isDown", false);
                animator.SetBool("isUp", false);
                animator.SetBool("isMoving", true);

                isMovingUp = false;
                isMovingDown = false;
                isMovingLeft = true;
                isMovingRight = false;
            }
            else if (pointB.x > pointA.x) //straight right
            {
                animator.SetBool("isRight", true);
                animator.SetBool("isLeft", false);
                animator.SetBool("isDown", false);
                animator.SetBool("isUp", false);
                animator.SetBool("isMoving", true);
                //idle stuff
                isMovingUp = false;
                isMovingDown = false;
                isMovingLeft = false;
                isMovingRight = true;

            }
            else if (pointB.x < pointA.x) //straight left
            {
                animator.SetBool("isLeft", true);
                animator.SetBool("isRight", false);
                animator.SetBool("isDown", false);
                animator.SetBool("isUp", false);
                animator.SetBool("isMoving", true);

                //idle
                isMovingUp = false;
                isMovingDown = false;
                isMovingLeft = true;
                isMovingRight = false;
            }
            else if (pointB.y > pointA.y) //straight up
            {
                animator.SetBool("isUp", true);
                animator.SetBool("isDown", false);
                animator.SetBool("isLeft", false);
                animator.SetBool("isRight", false);
                animator.SetBool("isMoving", true);
                //idle
                isMovingUp = true;
                isMovingDown = false;
                isMovingLeft = false;
                isMovingRight = false;

            }
            else if (pointB.y < pointA.y) //straight down
            {
                animator.SetBool("isDown", true);
                animator.SetBool("isRight", false);
                animator.SetBool("isLeft", false);
                animator.SetBool("isUp", false);
                animator.SetBool("isMoving", true);
                //idle 
                isMovingUp = false;
                isMovingDown = true;
                isMovingLeft = false;
                isMovingRight = false;
            }
            else
            {
                //not needed
            }

        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
            // updateAnim(0); //turns idle animation on
            if (isMovingUp == true)
            {
                animator.SetBool("isIdleUp", true);
                animator.SetBool("isIdleDown", false);
                animator.SetBool("isIdleRight", false);
                animator.SetBool("isIdleLeft", false);
                animator.SetBool("isMoving", false);
                animator.SetBool("isUp", false);
                //Debug.Log("Not Moving Up");


            }

            if (isMovingLeft == true)
            {

                animator.SetBool("isIdleUp", false);
                animator.SetBool("isIdleDown", false);
                animator.SetBool("isIdleRight", false);
                animator.SetBool("isIdleLeft", true);
                animator.SetBool("isMoving", false);
                animator.SetBool("isUp", false);
                //  Debug.Log("Not Moving Left");


            }
            if (isMovingRight == true)
            {
                animator.SetBool("isIdleUp", false);
                animator.SetBool("isIdleDown", false);
                animator.SetBool("isIdleRight", true);
                animator.SetBool("isIdleLeft", false);
                animator.SetBool("isMoving", false);
                animator.SetBool("isUp", false);
                // Debug.Log("Not Moving Right");



            }
            if (isMovingDown == true)
            {
                animator.SetBool("isIdleUp", false);
                animator.SetBool("isIdleDown", true);
                animator.SetBool("isIdleRight", false);
                animator.SetBool("isIdleLeft", false);
                animator.SetBool("isMoving", false);
                animator.SetBool("isUp", false);

            }

        }

    }
    void moveCharacter(Vector2 direction)
    {
        direction.x = direction.x * invertDirection;
        player.transform.Translate((direction * speed * Time.deltaTime));
    }


    private void updateAnim(int runDirection)
    {
        //changes animation
      //  theAnimator.SetInteger("runDirection", runDirection);

    }
}