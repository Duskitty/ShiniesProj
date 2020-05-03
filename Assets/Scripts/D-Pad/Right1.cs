using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right1 : MonoBehaviour
{
    // Start is called before the first frame update
    Collider rightButtonCollider;
    GameObject player;
    Animator animator;
    private float speed = 5f;
    bool isRight = false;
    Touch touch;
    void Start()
    {
        rightButtonCollider = GetComponent<Collider>();
        player = GameObject.FindWithTag("Player");
        animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            DPad.isUsingDPad = false;
            //to do add idle animations
        }
    }

   public void OnMouseDrag()
    {
        player.transform.Translate(new Vector3(speed * Time.deltaTime, 0f, 0f));


        animator.SetBool("isRight", true);
        animator.SetBool("isLeft", false);
        animator.SetBool("isDown", false);
        animator.SetBool("isUp", false);
        animator.SetBool("isMoving", true);

        PlayerMovement.isMovingUp = false;
        PlayerMovement.isMovingDown = false;
        PlayerMovement.isMovingLeft = false;
        PlayerMovement.isMovingRight = true;
        isRight = true;
        DPad.isUsingDPad = true;

    }
    public void MoveRight() {
        player.transform.Translate(new Vector3(speed * Time.deltaTime, 0f, 0f));


        animator.SetBool("isRight", true);
        animator.SetBool("isLeft", false);
        animator.SetBool("isDown", false);
        animator.SetBool("isUp", false);
        animator.SetBool("isMoving", true);

        PlayerMovement.isMovingUp = false;
        PlayerMovement.isMovingDown = false;
        PlayerMovement.isMovingLeft = false;
        PlayerMovement.isMovingRight = true;
        isRight = true;
        DPad.isUsingDPad = true;

    }
}

