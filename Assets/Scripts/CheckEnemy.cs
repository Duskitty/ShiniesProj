using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour
{
    public GameObject shroomBoi;
    private Animator shroomBoiAnimator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ShroomBoi_Exploder_0")
        {
            //taking damage 
            GameControlScript.health -= 1;
            shroomBoiAnimator.SetBool("Explode", true);
            StartCoroutine(gameObject.GetComponent<KnockBack>().KnockCo());
            StartCoroutine(collision.gameObject.GetComponent<MushroomMove>().Die());
        }
    }
    private void Start()
    {
        shroomBoiAnimator = shroomBoi.GetComponent<Animator>();
    }
}
