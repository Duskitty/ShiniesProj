using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{ 
    void OnCollisionEnter2D(Collision2D col)
    {
        GameControlScript.health -= 1;
        Debug.Log(GameControlScript.health);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().playSound("playerDamage");
        //Debug.Log("Player is hit");
    }
}
