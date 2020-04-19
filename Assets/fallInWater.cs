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

  void Start()
  {
    player = GameObject.Find("Player");
    playerSprite = player.GetComponent<SpriteRenderer>();
    psColor = playerSprite.color;
    respawnPoint = GameObject.Find("Respawn");
    isFalling = false;
    //GameObject.Find("Player").GetComponent<SheildBash>().enabled = false;//to do delete me after sprint on 4-7-2020
  }

  void OnTriggerStay2D(Collider2D col)
  {
    if (!isFalling)
    {
      StartCoroutine(playerFall());
    }
  }

  IEnumerator playerFall()
  {
    isFalling = true;
    player.GetComponent<PlayerMovement>().enabled = false;
    for (float f = 1f; f >= -0.05f; f -= 0.05f)
    {
      Debug.Log("here");
      Color c = playerSprite.color;
      c.a = f;
      playerSprite.color = c;
      yield return new WaitForSeconds(0.05f);
    }
    player.GetComponent<PlayerMovement>().enabled = true;
    player.transform.position = respawnPoint.transform.position;
    playerSprite.color = psColor;
    GameControlScript.health -= 1;
    isFalling = false;
    yield return null;
  }
}
