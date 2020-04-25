using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetL3P1 : MonoBehaviour
{
  public Sprite pressed;
  public Sprite unpressed;

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.name == "Player")
    {
      GetComponent<SpriteRenderer>().sprite = pressed;
      GameObject.Find("RedCrystal").transform.position = GameObject.Find("RedCrystalPos").transform.position;
      GameObject.Find("RedCrystal").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
      GameObject.Find("BlueCrystal").transform.position = GameObject.Find("BlueCrystalPos").transform.position;
      GameObject.Find("BlueCrystal").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
      GameObject.Find("GreenCrystal").transform.position = GameObject.Find("GreenCrystalPos").transform.position;
      GameObject.Find("GreenCrystal").transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
    }
  }

  void OnTriggerExit2D(Collider2D col)
  {
    if (col.name == "Player")
    {
      GetComponent<SpriteRenderer>().sprite = unpressed;
    }
  }
}
