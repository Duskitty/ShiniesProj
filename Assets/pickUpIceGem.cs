using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpIceGem : MonoBehaviour
{
    public GameObject iceGem;

    private void Start()
    {
        iceGem.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
      if(col.collider.name == "Player")
      {
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
            GameObject.Find("IceTilemap").GetComponent<IceControl>().enabled = false;
            Destroy(this.gameObject);
        iceGem.gameObject.SetActive(true);
      }
    }
}
