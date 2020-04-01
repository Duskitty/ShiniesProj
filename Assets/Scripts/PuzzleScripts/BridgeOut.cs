using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeOut : MonoBehaviour
{
    //public SpriteRenderer bridge;
    //public BoxCollider2D box;
    public bool buttonPressed;
    private bool bridgeComplete = false;
    //public bool boxOut;

    // Update is called once per frame
    void Update()
    {
      if (buttonPressed)
      {
        StartCoroutine(openBridge());
      }
      else
      {
        Debug.Log("HERE");
        StartCoroutine(closeBridge());
      }

        /*if(boxOut && GameObject.Find("AntMan").GetComponent<StunEnemy>().checkIsStunned())
        {
            //box.enabled = false;
        }
        else
        {
            //box.enabled = true;
        }*/
    }

    IEnumerator openBridge()
    {
      if (!bridgeComplete)
      {
        for (int i = 1; i < 5; i++)
        {
          if (!GameObject.Find("Bridge_0" + i).GetComponent<SpriteRenderer>().enabled)
          {
            GameObject.Find("Bridge_0" + i).GetComponent<SpriteRenderer>().enabled = true;
          }
          if (i != 4)
          {
            yield return new WaitForSeconds(0.7f);
          }
        }
        if (GameObject.Find("AntMan").GetComponent<StunEnemy>().checkIsStunned())
        {
          GameObject.Find("Bridge").GetComponent<BoxCollider2D>().enabled = false;
          bridgeComplete = true;
        }
        else
        {
          bridgeComplete = false;
        }
      }
      yield return null;
    }

    IEnumerator closeBridge()
    {
      if (bridgeComplete)
      {
        GameObject.Find("Bridge").GetComponent<BoxCollider2D>().enabled = true;
        for (int i = 4; i > 0; i--)
        {
          if (GameObject.Find("Bridge_0" + i).GetComponent<SpriteRenderer>().enabled)
          {
            GameObject.Find("Bridge_0" + i).GetComponent<SpriteRenderer>().enabled = false;
          }
          if (i != 1)
          {
            yield return new WaitForSeconds(0.7f);
          }
        }
      }
      bridgeComplete = false;
      yield return null;
    }

  void OnTriggerStay2D(Collider2D other)
    {
        //GameObject.Find("Player").GetComponent<PlayerMovement>().bridgeSafe = true;
        //GameObject.Find("ChasmColliderMiddle").GetComponent<BoxCollider2D>().enabled = false;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //GameObject.Find("Player").GetComponent<PlayerMovement>().bridgeSafe = false;
        //GameObject.Find("ChasmColliderMiddle").GetComponent<BoxCollider2D>().enabled = true;
    }
}
