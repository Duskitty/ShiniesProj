using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFix : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<PlayerMovement>().enabled = true;
        //GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<SheildBash>().enabled = true;
    }
}
