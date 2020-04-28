using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpIceGem : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
      if(col.collider.name == "Player")
      {
        Destroy(this.gameObject);
        //Add in code to put ice gem on the shield
      }
    }
}
