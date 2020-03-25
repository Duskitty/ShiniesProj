using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
  public Rigidbody2D player;
  private GameObject badGuy;
  private Vector2 playervel;
  [SerializeField] public float knockTime;
  [SerializeField] public float thrust;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("enemy"))
    {
      Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
       

      if (hit != null)
      {
        Vector2 difference = hit.transform.position - transform.position;
        difference = difference.normalized * thrust;
        print(difference);
        player.AddForce(-difference, ForceMode2D.Impulse);
        print("Oof!");
      }

      /*Debug.Log("Hit enemy");
      badGuy = other.transform.gameObject;
      player.isKinematic = false;
      //Vector2 difference = (player.transform.position - badGuy.transform.position);
      //difference = difference.normalized * thrust;
      playervel = player.GetComponent<Rigidbody2D>().velocity;
      player.GetComponent<Rigidbody2D>().velocity = -playervel * thrust;
      */
    }

  }
  public IEnumerator KnockCo()
  {
    yield return new WaitForSeconds(knockTime);  //knocktime is the amount of time the game will "pause" for the knock back
    player.velocity = Vector2.zero;
    player.isKinematic = false;
  }
}


