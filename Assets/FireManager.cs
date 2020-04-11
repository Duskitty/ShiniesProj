using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
  private GameObject player;
  private bool fireGem;
  private bool pressed;
  // Start is called before the first frame update
  void Start()
    {
      player = GameObject.Find("Player");
    }

    // Update is called once per frame
    /*
    void Update()
    {
      pressed = player.GetComponent<BeamButton>().isPressed();
      fireGem = player.GetComponent<GemPick>().returnFireGem();
      if (pressed && fireGem)
      {
        player.transform.GetChild(10).GetComponent<castBeam>().castFire();
        player.transform.GetChild(10).GetComponent<LineRenderer>().enabled = false;
      }
    }*/
    public void FireStuff()
    {
        fireGem = player.GetComponent<GemPick>().returnFireGem();
        if (GemPick.fireGem)
        {
            player.transform.GetChild(10).GetComponent<castBeam>().castFire();
            player.transform.GetChild(10).GetComponent<LineRenderer>().enabled = false;
        }
    }
}
