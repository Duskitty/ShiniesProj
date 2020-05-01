using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class right : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Animator animator;

    void Start()
    {
        player = GameObject.Find("Player");
        animator = GameObject.Find("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        player.transform.Translate(new Vector3(PlayerMovement.speed * Time.deltaTime, 0f, 0f));


        animator.SetBool("isRight", true);
        animator.SetBool("isLeft", false);
        animator.SetBool("isDown", false);
        animator.SetBool("isUp", false);
        animator.SetBool("isMoving", true);

       PlayerMovement. isMovingUp = false;
       PlayerMovement. isMovingDown = false;
       PlayerMovement. isMovingLeft = false;
        PlayerMovement.isMovingRight = true;


    }
}

