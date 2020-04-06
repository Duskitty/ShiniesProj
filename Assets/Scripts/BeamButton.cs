using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamButton : MonoBehaviour
{
  public bool pressed;

  void Start()
  {
    pressed = false;
  }

   public void ButtonPress() {
    /*if (GemPick.fireGem == true && GameControlScript.charges >= 1)
    {
        // GameObject.Find("")
    }
    else if (GemPick.iceGem == true && GameControlScript.charges >= 1)
    {
        //add stuff later 
    }
    else if (GemPick.reflectGem == true && GameControlScript.charges >= 1) { 
        //add stuff later 

    }*/
    //Debug.Log("in button press");
      if (pressed)
      {
        pressed = false;
      }
      else
      {
        pressed = true;
      }
    
    }

  public bool isPressed()
  {
    //Debug.Log(pressed);
    return pressed;
  }

}
