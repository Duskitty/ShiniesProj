using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour
{
    GameObject player;
    Animator animator;
    float speed = 5f;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Right.isUsingDPad = true;
        player.transform.Translate(new Vector3(0f, speed * Time.deltaTime, 0f));


        animator.SetBool("isRight", false);
        animator.SetBool("isLeft", false);
        animator.SetBool("isDown", false);
        animator.SetBool("isUp", true);
        animator.SetBool("isMoving", true);

        PlayerMovement.isMovingUp = true;
        PlayerMovement.isMovingDown = false;
        PlayerMovement.isMovingLeft = false;
        PlayerMovement.isMovingRight = false;


    }
}
