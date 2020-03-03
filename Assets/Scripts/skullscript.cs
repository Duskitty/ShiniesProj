using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skullscript : MonoBehaviour
{ 
    void OnCollisionEnter2D(Collision2D col)
    {
        GameControlScript.health -= 1;
        Debug.Log("Player is hit");
    }
}
