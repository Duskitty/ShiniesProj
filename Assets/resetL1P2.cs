using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetL1P2 : MonoBehaviour
{
  public Sprite pressed;
  public Sprite unpressed;

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.name == "Player" || col.tag == "Pyramid")
    {
      GetComponent<SpriteRenderer>().sprite = pressed;
      GameObject.Find("rock00").transform.position = GameObject.Find("rock00Pos").transform.position;
      GameObject.Find("rock00").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
      GameObject.Find("rock01").transform.position = GameObject.Find("rock01Pos").transform.position;
      GameObject.Find("rock01").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
      GameObject.Find("rock02").transform.position = GameObject.Find("rock02Pos").transform.position;
      GameObject.Find("rock02").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
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
