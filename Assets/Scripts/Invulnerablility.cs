using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invulnerablility : MonoBehaviour
{

    public float invin;
    public GameObject shroom;
    private Animator shroomAnimator;
    private void Start()
    {
        shroomAnimator = shroom.GetComponent<Animator>();
    }
    private void Update()
    {
        invin -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.name == "ShroomBoi_Exploder_0") && (invin > 0 || SheildBash.isSheildBashing == true|| collision.gameObject.CompareTag("bush")|| collision.gameObject.CompareTag("sheild")))
        {
            shroomAnimator.SetBool("Explode", true);
            Debug.Log("No damage");
            StartCoroutine(shroom.GetComponent<MushroomMove>().Die());

        }
        else {
            invin = 1f;
            StartCoroutine(GetComponent<KnockBack>().KnockCo());
           // GameControlScript.health -= 1;
            Debug.Log("Damage");
            shroomAnimator.SetBool("Explode", true);
           StartCoroutine( shroom.GetComponent<MushroomMove>().Die());
        }
    }

}
