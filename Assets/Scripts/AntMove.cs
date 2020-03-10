using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMove : MonoBehaviour
{
    private float horizontal = 0f;
    private float vertical = 0f;
    public Animator animat;
    public float Delay;
    public bool isShieldBahsing = false;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (horizontal > 0)
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
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            animat.SetBool("Stab", true);
            if (isShieldBahsing)
            {
                //no damage taken
            }
            else
            {
                // no shield bash = 1 less heart
                GameControlScript.health -= 1;
                print(col.name);
                StartCoroutine(col.GetComponent<KnockBack>().KnockCo());


            }

          
        }
    }
}
