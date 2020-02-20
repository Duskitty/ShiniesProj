using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Update is called once per frame
    void FixedUpdate()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        //animator.SetFloat("Speed", Mathf.Abs(verticalMove));
        if (textBoxAnimator.GetBool("isOpen")){
            return;

        }
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(new Vector3(0f, speed * Time.deltaTime,0f));

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0f, -speed * Time.deltaTime,0f));

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed*Time.deltaTime,0f,0f));
            animator.SetBool("isLeft", true);
            if (horizontalMove < 0.01) {
                animator.SetBool("isLeft", true);


            }

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed*Time.deltaTime,0f,0f));
            animator.SetBool("isRight", true);


        }
    }
 
}
