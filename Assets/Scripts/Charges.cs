using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charges : MonoBehaviour
{
     void Update()
    {
        if (Input.GetKey(KeyCode.C)) {

            GameControlScript.charges -= 1;//decrmate the charges
            if (GameControlScript.charges < 0) {
                GameControlScript.charges = 0;//make sure charges dont go below zero
            
            }
        
        }
    }
}
