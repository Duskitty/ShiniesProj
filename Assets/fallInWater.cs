using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallInWater : MonoBehaviour
{
  private GameObject player;
  private GameObject respawnPoint;
  private SpriteRenderer playerSprite;
  private Color psColor;
  private int spinPos;
  private bool isFalling;
  private GameObject fallingObj;

  void Start()
  {
    player = GameObject.Find("Player");
    playerSprite = player.GetComponent<SpriteRenderer>();
    //psColor = playerSprite.color;
    respawnPoint = GameObject.Find("Respawn");
    isFalling = false;
    //GameObject.Find("Player").GetComponent<SheildBash>().enabled = false;//to do delete me after sprint on 4-7-2020
  }

  void OnTriggerStay2D(Collider2D col)
  {
    if (!isFalling)
    {
      fallingObj = GameObject.Find(col.name);
      if (fallingObj == player || fallingObj.tag == "IceBlock" || fallingObj.tag == "EnemyIceBlock")
      {
        psColor = fallingObj.GetComponent<SpriteRenderer>().color;
        StartCoroutine(playerFall(fallingObj));
      }
    }
  }

  IEnumerator playerFall(GameObject fallingObj)
  {
    isFalling = true;
      if (fallingObj == player)
      {
        player.GetComponent<PlayerMovement>().enabled = false;
      }

      
      for (float f = 1f; f >= -0.05f; f -= 0.05f)
      {
        if (fallingObj != null)
        {
          Debug.Log("here");
          Color c = fallingObj.GetComponent<SpriteRenderer>().color;
          c.a = f;
          fallingObj.GetComponent<SpriteRenderer>().color = c;
          yield return new WaitForSeconds(0.05f);
        }
      }

      if (fallingObj == player)
      {
        player.GetComponent<PlayerMovement>().enabled = true;
        player.transform.position = respawnPoint.transform.position;
        playerSprite.color = psColor;
        GameControlScript.health -= 1;
      }
      else
      {
        Destroy(fallingObj);
      }
    
    isFalling = false;
    yield return null;
  }
}
