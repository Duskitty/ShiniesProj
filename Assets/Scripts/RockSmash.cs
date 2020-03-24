using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSmash : MonoBehaviour
{
    private bool isBashing = false;
    public float rockDelay;
    public Animator animi;


    public void OnCollisionEnter2D(Collision2D col)
    {
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftShift) && pickUpMirror.hasSheild==true) { 
            
                animi.SetBool("Break", true);
                StartCoroutine(RockDie());
            

        }
    }



    public void SetIsBashing(bool bashing) {
        Debug.Log("made it to the setter");
        isBashing = bashing;
        Debug.Log(isBashing);
    }

    public IEnumerator RockDie() {
        yield return new WaitForSeconds(rockDelay);
        Destroy(gameObject);
        animi.SetBool("Break", false);

    }
}
