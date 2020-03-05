using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunlightTrigger : MonoBehaviour
{
  public bool inSunlight; 
  public void OnTriggerEnter2D(Collider2D thing)
  {
    inSunlight = true;
    //Debug.Log("In sun");
  }

  public void OnTriggerExit2D(Collider2D thing)
  {
    inSunlight = false;
    //Debug.Log("Not in sun");
  }
}
