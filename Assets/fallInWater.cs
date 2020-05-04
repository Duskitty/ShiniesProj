using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fallInWater : MonoBehaviour
{
  private GameObject player;
  private GameObject respawnPoint;
  private GameObject secondRespawn;
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
    /*if(SceneManager.GetActiveScene().name == "World 3 P2")
    {
      secondRespawn = GameObject.Find("secondRespawn");
    }*/
    isFalling = false;
    //GameObject.Find("Player").GetComponent<SheildBash>().enabled = false;//to do delete me after sprint on 4-7-2020
  }

  void OnTriggerStay2D(Collider2D col)
  {
    fallingObj = GameObject.Find(col.name);
    if (!isFalling && (fallingObj.tag == "EnemyIceBlock" || (fallingObj.name == player.name && !player.GetComponent<falling>().isFalling)))
    {
      if (fallingObj == player || fallingObj.tag == "IceBlock" || fallingObj.tag == "EnemyIceBlock")
      {
        if (fallingObj.GetComponent<SpriteRenderer>().color.a == 1)
        {
          player.GetComponent<falling>().isFalling = true;
          psColor = fallingObj.GetComponent<SpriteRenderer>().color;
          StartCoroutine(playerFall(fallingObj));
        }
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
          //Debug.Log("here");
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
        player.GetComponent<falling>().isFalling = false;
      }
      else if(fallingObj.tag == "EnemyIceBlock")
      {
        Destroy(fallingObj.GetComponent<containsEnemy>().enemy);
        Destroy(fallingObj);
      }
      else
      {
        Destroy(fallingObj);
      }
    
    isFalling = false;
    yield return null;
  }
}
