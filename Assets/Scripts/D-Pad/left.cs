using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    GameObject player;
    Animator animator;
    private float speed = 5f;
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

        player.transform.Translate(new Vector3(-speed * Time.deltaTime, 0f, 0f));


        animator.SetBool("isRight", false);
        animator.SetBool("isLeft", true);
        animator.SetBool("isDown", false);
        animator.SetBool("isUp", false);
        animator.SetBool("isMoving", true);

        PlayerMovement.isMovingUp = false;
        PlayerMovement.isMovingDown = false;
        PlayerMovement.isMovingLeft = true;
        PlayerMovement.isMovingRight = false;


    }
}
