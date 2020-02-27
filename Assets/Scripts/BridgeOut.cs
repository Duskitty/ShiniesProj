using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeOut : MonoBehaviour
{
    public SpriteRenderer bridge;
    public BoxCollider2D box;
    public bool buttonPressed;
    public bool boxOut;

    // Update is called once per frame
    void Update()
    {
        if(buttonPressed == false)
        {
            bridge.enabled = false;
        }
        else
        {
            bridge.enabled = true;
        }

        if(boxOut == false)
        {
            box.enabled = false;
        }
        else
        {
            box.enabled = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().bridgeSafe = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().bridgeSafe = false;
    }
}
