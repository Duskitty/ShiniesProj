using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMove : MonoBehaviour
{
    private float horizontal = 0f;
    private float vertical = 0f;
    public Animator animat;
    public float Delay;
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
   private void OnCollisionEnter2D(Collision2D col)
    {
       animat.SetBool("Explode", true);
        GameControlScript.health -= 1;

        StartCoroutine(Die());
        
    }
    public IEnumerator Die()
    {
        yield return new WaitForSeconds(Delay);
        Destroy(gameObject);
    }
    public void SheildBash() {
        animat.SetBool("Explode", true);
        Debug.Log("about to sheild bash");

        StartCoroutine(Die());


    }
}
