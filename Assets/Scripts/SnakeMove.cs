using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    private float horizontal = 0f;
    private float vertical = 0f;
    public Animator animat;
    public float Delay;
    // animations for mushroom man
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
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && SheildBash.isSheildBashing == true && Invincible.isHit == false)
        {
            Debug.Log("Im sheild bashing " + gameObject.name);
            animat.SetBool("Explode", true);
            SheildBash.isSheildBashing = false;
            GameObject.Find("Player").GetComponent<SheildBash>().RestoreMovment();
            StartCoroutine(Die());
            //this is when the player is sheild bashing
            //dont do damage 
            //also the player isnt hit so dont change the Invincible.isHit to true 

        }
        else if (col.gameObject.name == "Player" && SheildBash.isSheildBashing == false && Invincible.isHit == false)
        {
            Debug.Log("Im not sheild bashing " + gameObject.name);
            Invincible.isHit = true;
            animat.SetBool("Explode", true);
            GameControlScript.health -= 1;
            StartCoroutine(col.GetComponent<KnockBack>().KnockCo());
            StartCoroutine(Die());


        }
    }
    public IEnumerator Die()
    {
        yield return new WaitForSeconds(Delay);
        Destroy(gameObject);

    }
    public void Bash()
    {
        animat.SetBool("Explode", true);
        Debug.Log("about to sheild bash");

        StartCoroutine(Die());
        // ChangeScene();
    }
}
