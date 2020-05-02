using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBoiMove : MonoBehaviour
{
    private float horizontal = 0f;
    public Animator animat;
    public float Delay;
    public bool isShieldBahsing = false;

    void Update()
    {
        if (transform.position == GetComponent<WaypointFinder>().waypoints[0].position)
        {
            animat.SetBool("isRight", false);
            animat.SetBool("isMoving", true);
            animat.SetBool("isLeft", true);
            animat.SetBool("isUp", false);
            animat.SetBool("isDown", false);
        }
        if (transform.position == GetComponent<WaypointFinder>().waypoints[1].position)
        {
            animat.SetBool("isRight", true);
            animat.SetBool("isMoving", true);
            animat.SetBool("isLeft", false);
            animat.SetBool("isUp", false);
            animat.SetBool("isDown", false);
        }
        
    }
    
    public void OnTriggerEnter2D(Collider2D col)
    {
       if (col.gameObject.name == "Player" && SheildBash.isSheildBashing == false && Invincible.isHit == false)
        {
            Invincible.isHit = true;
            GameControlScript.health -= 1;
            StartCoroutine(col.GetComponent<KnockBack>().KnockCo());
            Invincible.isHit = true;

        }
    }
    
}
