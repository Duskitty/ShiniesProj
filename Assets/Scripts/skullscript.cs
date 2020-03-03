using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skullscript : MonoBehaviour
{ 
    void OnTriggerEnter2D(Collider2D col)
    {
        GameControlScript.health -= 1;
        Debug.Log("Player is hit");
    }
}
