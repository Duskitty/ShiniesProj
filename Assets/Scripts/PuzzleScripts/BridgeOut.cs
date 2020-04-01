using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeOut : MonoBehaviour
{
    //public SpriteRenderer bridge;
    //public BoxCollider2D box;
    public bool buttonPressed;
    private int bridgeState;
    //private bool bridgeComplete = false;
    //public bool boxOut;

    void Start()
    {
      bridgeState = 0;
      StartCoroutine(bridgeCoroutine());
    }

    IEnumerator bridgeCoroutine()
    {
      while (true)
      {
        if (buttonPressed)
        {
          extendBridge();
        }
        else
        {
          retractBridge();
        }

        if (GameObject.Find("AntMan").GetComponent<StunEnemy>().checkIsStunned())
        {
          GameObject.Find("Bridge").GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
          GameObject.Find("Bridge").GetComponent<BoxCollider2D>().enabled = true;
        }

        yield return new WaitForSeconds(0.1f);
      }
    }

    public void extendBridge()
    { 
      if(bridgeState == 0)
      {
        GameObject.Find("Bridge_01").GetComponent<SpriteRenderer>().enabled = true;
      }
      else if (bridgeState == 1)
      {
        GameObject.Find("Bridge_02").GetComponent<SpriteRenderer>().enabled = true;
      }
      else if (bridgeState == 2)
      {
        GameObject.Find("Bridge_03").GetComponent<SpriteRenderer>().enabled = true;
      }
      else if (bridgeState == 3)
      {
        GameObject.Find("Bridge_04").GetComponent<SpriteRenderer>().enabled = true;
      }

      if (bridgeState >= 0 && bridgeState <= 3)
      {
        bridgeState++;
      }
    }

    public void retractBridge()
    {
      if (bridgeState == 4)
      {
        GameObject.Find("Bridge_04").GetComponent<SpriteRenderer>().enabled = false;
      }
      else if (bridgeState == 3)
      {
        GameObject.Find("Bridge_03").GetComponent<SpriteRenderer>().enabled = false;
      }
      else if (bridgeState == 2)
      {
        GameObject.Find("Bridge_02").GetComponent<SpriteRenderer>().enabled = false;
      }
      else if (bridgeState == 1)
      {
        GameObject.Find("Bridge_01").GetComponent<SpriteRenderer>().enabled = false;
      }

      if(bridgeState > 0)
      {
        bridgeState--;
      }
    }
}
