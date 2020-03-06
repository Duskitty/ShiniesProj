using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMovement : MonoBehaviour
{
    private float horizontal = 0f;
    private float vertical = 0f;
    public Animator animat;
    // animations for mushroom man

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical= Input.GetAxis("Vertical");

        if(horizontal > 0)
        {
            animat.SetBool("Right", true);
            animat.SetBool("Moving", true);
            animat.SetBool("Left", false);
            animat.SetBool("Up", false);
            animat.SetBool("Down", false);
        }
        if (horizontal < 0)
        {
            animat.SetBool("Right", false);
            animat.SetBool("Moving", true);
            animat.SetBool("Left", true);
            animat.SetBool("Up", false);
            animat.SetBool("Down", false);
        }
        if (vertical > 0)
        {
            animat.SetBool("Right", false);
            animat.SetBool("Moving", true);
            animat.SetBool("Left", false);
            animat.SetBool("Up", true);
            animat.SetBool("Down", false);
        }
        if (vertical < 0)
        {
            animat.SetBool("Right", false);
            animat.SetBool("Moving", true);
            animat.SetBool("Left", false);
            animat.SetBool("Up", false);
            animat.SetBool("Down", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameControlScript.health -= 1;
        animat.SetBool("Explode", true);
        Destroy(gameObject, 1);
        transform.Translate(new Vector3(100, 100, 0));

    }
}
