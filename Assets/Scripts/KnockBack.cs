using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float thrust;
    public Rigidbody2D player;
    public GameObject badGuy;
    public float knockTime;
   
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy") {
            Debug.Log("Hit");
            player.isKinematic = false;
            Vector2 difference = (player.transform.position - badGuy.transform.position);
            difference = difference.normalized * thrust;
            player.AddForce(difference, ForceMode2D.Impulse);
            StartCoroutine(KnockCo());
        }

    }
    public IEnumerator KnockCo() {

        yield return new WaitForSeconds(knockTime);  //knocktime is the amount of time the game will "pause" for the knock back
        player.velocity = Vector2.zero;
      //  player.isKinematic = true;
    }
   
}


