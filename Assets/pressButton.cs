using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressButton : MonoBehaviour
{
  private bool isPressed;
  public Sprite pressed;
  public Sprite unpressed;

    // Start is called before the first frame update
    void Start()
    {
      isPressed = false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
      isPressed = true;
      GetComponent<SpriteRenderer>().sprite = pressed;
    }

    void OnTriggerExit2D(Collider2D col)
    {
      isPressed = false;
      GetComponent<SpriteRenderer>().sprite = unpressed;
    }

    public bool getIsPressed()
    {
      return isPressed;
    }
}
