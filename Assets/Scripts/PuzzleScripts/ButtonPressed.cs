using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    public SpriteRenderer button;
    public Sprite button_unpressed;
    public Sprite button_pressed;
    public bool pressed = false;

    // Update is called once per frame
    void Update()
    {
        if(pressed == false)
        {
            button.sprite = button_unpressed;
        }
        else
        {
            button.sprite = button_pressed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Find("Bridge_Out").GetComponent<BridgeOut>().buttonPressed = true;
        GameObject.Find("Bridge_Out").GetComponent<Renderer>().enabled = true;
        GameObject.Find("Bridge_Out").GetComponent<BridgeOut>().boxOut = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        pressed = true;
    }

    void OnTriggerExit2D (Collider2D other)
    {
        pressed = false;
        GameObject.Find("Bridge_Out").GetComponent<BridgeOut>().buttonPressed = false;
        GameObject.Find("Bridge_Out").GetComponent<Renderer>().enabled = false;
        GameObject.Find("Bridge_Out").GetComponent<BridgeOut>().boxOut = false;
    }
}
