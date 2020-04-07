﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakTile : MonoBehaviour
{
  private GameObject player;
  private GameObject respawnPoint;
  private Animator playerDirection;
  private SpriteRenderer playerSprite;
  private Color psColor;
  private int spinPos;

  void Start()
  {
    player = GameObject.Find("Player");
    playerDirection = player.GetComponent<Animator>();
    playerSprite = player.GetComponent<SpriteRenderer>();
    psColor = playerSprite.color;
    respawnPoint = GameObject.Find("Respawn");
        GameObject.Find("Player").GetComponent<SheildBash>().enabled = false;//to do delete me after sprint on 4-7-2020
  }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (this.GetComponent<SpriteRenderer>().enabled)
    {
      StartCoroutine(animateTile());
    }
    //GameControlScript.health -= 1;
    StartCoroutine(playerFall());
    //player.transform.position = respawnPoint.transform.position;
  }

  IEnumerator playerFall()
  {
    player.GetComponent<PlayerMovement>().enabled = false;
    for (float f = 1f; f >= -0.05f; f -= 0.05f)
    {
      Color c = playerSprite.color;
      c.a = f;
      playerSprite.color = c;
      yield return new WaitForSeconds(0.05f);
    }

    player.transform.position = respawnPoint.transform.position;
    playerSprite.color = psColor;
    player.GetComponent<PlayerMovement>().enabled = true;
    yield return null;
  }

  IEnumerator animateTile()
  {
    this.GetComponent<Animator>().SetBool("isBroken", true);
    yield return new WaitForSeconds(0.4f);
    this.GetComponent<Animator>().SetBool("isBroken", false);
    this.GetComponent<SpriteRenderer>().enabled = false;

    yield return null;
  }
}
