using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetL2P2 : MonoBehaviour
{
  public Sprite pressed;
  public Sprite unpressed;

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.name == "Player" || col.tag == "Pyramid")
    {
      GetComponent<SpriteRenderer>().sprite = pressed;
      GameObject.Find("miragePyramid00").transform.position = GameObject.Find("mPyramid00Pos").transform.position;
      GameObject.Find("miragePyramid00").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
      GameObject.Find("miragePyramid01").transform.position = GameObject.Find("mPyramid01Pos").transform.position;
      GameObject.Find("miragePyramid01").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
    }
  }

  void OnTriggerExit2D(Collider2D col)
  {
    if (col.name == "Player" || col.tag == "Pyramid")
    {
      GetComponent<SpriteRenderer>().sprite = unpressed;
    }
  }
}
