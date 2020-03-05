using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMovement : MonoBehaviour
{
    private float horizontalMovment = 0f;
    private float verticalMovment = 0f;
    public Animator anim;
    //animations script for mushroom man

    // Update is called once per frame
    void Update()
    {
        if (horizontalMovment > 0)
        {
            anim.SetBool("Right", true);
            anim.SetBool("Moving", true);
            anim.SetBool("Left", false);
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);



        }
        if (horizontalMovment < 0)
        {
            anim.SetBool("Left", true);
            anim.SetBool("Moving", true);
            anim.SetBool("Right", false);
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);


        }
        if (verticalMovment > 0)
        {
            anim.SetBool("Left", false);
            anim.SetBool("Moving", true);
            anim.SetBool("Right", false);
            anim.SetBool("Up", true);
            anim.SetBool("Down", false);

        }
        if (verticalMovment < 0)
        {
            anim.SetBool("Left", false);
            anim.SetBool("Moving", true);
            anim.SetBool("Right", false);
            anim.SetBool("Up", false);
            anim.SetBool("Down", true);

        }
    }
}
