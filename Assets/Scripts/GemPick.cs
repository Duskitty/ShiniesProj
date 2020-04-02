using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPick : MonoBehaviour
{
    public static bool reflectGem = false;
    public static bool fireGem = false;
    public static bool iceGem = false;
    //add other gems later 



   public void FireGem() {
        fireGem = true;
        reflectGem = false;
        iceGem = false;
    
    }
  public  void ReflectGem() {

        fireGem = false;
        reflectGem = true;
        iceGem = false;
    }
   public void IceGem() {
        fireGem = false;
        reflectGem = false;
        iceGem = true;

    }
}