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
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("sunbeam"))
        {
            GameControlScript.charges += 1;
            if (GameControlScript.charges > 1)
            {
                GameControlScript.charges = 1;//keep for world one get ride for other worlds :)

            }

        }
    }
}
