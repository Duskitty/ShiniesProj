using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeManager : MonoBehaviour
{
  public bool left;

  void Start()
  {
    left = true;
  }

   void OnTriggerExit2D(Collider2D col)
   {
    if (left)
    {
      left = false;
    }
    else
    {
      left = true;
    }
    Debug.Log(left);
   }
}
