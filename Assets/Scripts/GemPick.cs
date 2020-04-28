using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPick : MonoBehaviour
{
  public static bool reflectGem = false;
  public static bool fireGem = false;
  public static bool iceGem = false;
  //add other gems later 
  private Color fireColor;
  private Color reflectColor;
  private Color iceColor;


  public void FireGem()
  {
    fireGem = true;
    reflectGem = false;
    iceGem = false;
    Debug.Log("Fire gem selected");
  }
  public void ReflectGem()
  {

    fireGem = false;
    reflectGem = true;
    iceGem = false;
    Debug.Log("Reflect gem selected");

  }
  public void IceGem()
  {
    fireGem = false;
    reflectGem = false;
    iceGem = true;
    Debug.Log("Ice gem selected");
  }

  public bool returnReflectGem()
  {
    return reflectGem;
  }

  public bool returnFireGem()
  {
    return fireGem;
  }
}