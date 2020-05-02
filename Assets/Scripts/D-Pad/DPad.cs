using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPad : MonoBehaviour
{
    // Start is called before the first frame update

    Collider rightButtonCollider;
    Collider leftButtonCollider;
    Collider upButtonCollider;
    Collider downButtonCollider;
    //class varriables
    Right right;
    Left left;
    Up up;
    Down down;

    //Here you could declare a variable for the script on the right button

    void Start()
    {
        rightButtonCollider = GameObject.Find("Right").GetComponent<Collider>();
        leftButtonCollider = GameObject.Find("Left").GetComponent<Collider>();
        upButtonCollider = GameObject.Find("Up").GetComponent<Collider>();
        downButtonCollider = GameObject.Find("Down").GetComponent<Collider>();
        //Here you could grab the script on the right button and assign it to a class variable
    }


    void Update()
    {
        //This will detect if the user touched the right button.
        //it won't actually move anything
        //It is only setup for the right button


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 pos = touch.position;

            if (rightButtonCollider.bounds.Contains(pos))
            {
                right.OnMouseDown();
                //here you could call the function of the script on the right button to move the character

            }
        }


    }
}
