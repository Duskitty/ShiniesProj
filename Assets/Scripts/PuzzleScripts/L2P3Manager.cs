using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2P3Manager : MonoBehaviour
{
    public bool pressed;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
      if (pressed)
      {
        player.transform.GetChild(10).GetComponent<castBeam>().castFire();
        player.transform.GetChild(10).GetComponent<castBeam>().disableLight();
      }
    }
}
