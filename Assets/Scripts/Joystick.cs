using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    /*
    public Transform player;
    public float speed = 0.001f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
           // pointA = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
           // pointB = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else {
            touchStart = false;
        }
    }

    private void FixedUpdate()
    {
        if (touchStart) {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            print(direction);
            moveCharacter(direction);
        }
    }

    void moveCharacter(Vector2 direction) {

        player.Translate(Vector2.ClampMagnitude(direction.normalized * speed * Time.deltaTime, speed));
    }
    */
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
    Vector2 direction;
    public Transform circle;
    public Transform outerCircle;
    private Vector2 movmentDirection;
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            circle.transform.position = pointA * -1;
            outerCircle.transform.position = pointA * -1;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }

    }
    //take what ever they touched and compare it to the inital point of the joystick
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
          direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction );

            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * -1;
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }

       PlayerAnimator(direction);
    }
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
    void PlayerAnimator(Vector2 direction) {
        //figure out what way the joystick was moved
        var circleDirectionX = direction.x - circle.transform.position.x;
        var cirlceDirectionY = direction.y - circle.transform.position.y;
       // var circleDirection = outerCircle.transform.position - circle.transform.position;
        if (circleDirectionX>0) {//looking right
            animator.SetBool("isRight", true);
            animator.SetBool("isLeft", false);
            animator.SetBool("isDown", false);
            animator.SetBool("isUp", false);
            animator.SetBool("isMoving", true);

        }
        if (circleDirectionX < 0)//looking left
        {
            animator.SetBool("isLeft", true);
            animator.SetBool("isRight", false);
            animator.SetBool("isDown", false);
            animator.SetBool("isUp", false);
            animator.SetBool("isMoving", true);

        }
       if (cirlceDirectionY > 0)//looking up
        {
            animator.SetBool("isUp", true);
            animator.SetBool("isDown", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);
            animator.SetBool("isMoving", true);

        }
        if (cirlceDirectionY < 0)//looking down
        {
            animator.SetBool("isDown", true);
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isUp", false);
            animator.SetBool("isMoving", true);

        }
    }
}

