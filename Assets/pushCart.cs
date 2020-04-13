using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushCart : MonoBehaviour
{
  public string color;
  private GameObject player;
  private Animator playerDirection;
  private GameObject gem;

    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("Player");
      playerDirection = player.GetComponent<Animator>();
      if(color == "red")
      {
        gem = GameObject.Find("RedCrystal");
      }
      else if (color == "green")
      {
        gem = GameObject.Find("GreenCrystal");
      }
      else if (color == "blue")
      {
        gem = GameObject.Find("BlueCrystal");
      }
  }

    void OnCollisionStay2D(Collision2D col)
    {
      if (col.collider.name == player.name && (playerDirection.GetBool("isLeft") || playerDirection.GetBool("isRight")))
      {
        gem.GetComponent<Animator>().SetBool("isMoving", true);
      }
      else
      {
        gem.GetComponent<Animator>().SetBool("isMoving", false);
      }
    }

  void OnCollisionExit2D(Collision2D col)
  {
    if (col.collider.name == player.name)
    {
      gem.GetComponent<Animator>().SetBool("isMoving", false);
    }
  }
}
