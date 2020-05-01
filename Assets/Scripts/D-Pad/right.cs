using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Animator animator;
    private float speed = 5f;
    bool isRight = false;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRight&& Input.GetMouseButtonDown(0))
        {

            OnMouseDown();

        }
        if (Input.GetMouseButtonUp(0)) {

            isRight = false;
        }
    }

    void OnMouseDown()
    {
        player.transform.Translate(new Vector3(speed * Time.deltaTime, 0f, 0f));



        animator.SetBool("isRight", true);
        animator.SetBool("isLeft", false);
        animator.SetBool("isDown", false);
        animator.SetBool("isUp", false);
        animator.SetBool("isMoving", true);

       PlayerMovement. isMovingUp = false;
       PlayerMovement. isMovingDown = false;
       PlayerMovement. isMovingLeft = false;
        PlayerMovement.isMovingRight = true;
        isRight = true;

    }
}

