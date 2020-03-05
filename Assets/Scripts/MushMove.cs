using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushMove : MonoBehaviour
{
    private float horizontalMovment = 0f;
    private float verticalMovment = 0f;
    public Animator anim;
    //animations script for mushroom man
    void Update()
    {
        horizontalMovment = Input.GetAxis("Horizontal");
        verticalMovment = Input.GetAxis("Vertical");


        if (horizontalMovment > 0) {
            anim.SetBool("Right", true);
            anim.SetBool("Moving", true);
            anim.SetBool("Left", false);
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);



        }
        if (horizontalMovment < 0) {
            anim.SetBool("Left", true);
            anim.SetBool("Moving", true);
            anim.SetBool("Right", false);
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);


        }
        if (verticalMovment > 0) {
            anim.SetBool("Left", false);
            anim.SetBool("Moving", true);
            anim.SetBool("Right", false);
            anim.SetBool("Up", true);
            anim.SetBool("Down", false);

        }
        if (verticalMovment <0)
        {
            anim.SetBool("Left", false);
            anim.SetBool("Moving", true);
            anim.SetBool("Right", false);
            anim.SetBool("Up", false);
            anim.SetBool("Down", true);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("Explode", true);
        GameControlScript.health -= 1;
        if(anim.GetBool("Explode"))
        {
            Destroy(gameObject, 1);
            //this is here because the enemy is still there for a second so this is to make sure it can not hit you twice
            transform.Translate(new Vector3(100,100,0));
        }


    }
}
