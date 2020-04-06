using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2P3Manager : MonoBehaviour
{
    //public bool pressed;
    private GameObject player;
    private bool inSun;
    private bool pressed;
    private bool reflectGem;
    private bool fireGem;
    private int charges;

    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
      inSun = GameObject.Find("sunPatch00").GetComponent<SunlightTrigger>().inSunlight;
      pressed = player.GetComponent<BeamButton>().isPressed();
      reflectGem = player.GetComponent<GemPick>().returnReflectGem();
      fireGem = player.GetComponent<GemPick>().returnFireGem();
      charges = GameControlScript.charges;

      if ((inSun && !pressed) || (inSun && pressed && reflectGem) || (!inSun && pressed && reflectGem))
      {
        player.transform.GetChild(10).GetComponent<castBeam>().reflect(null);
      }
      else if (pressed && fireGem)
      {
        player.transform.GetChild(10).GetComponent<castBeam>().castFire();
        player.transform.GetChild(10).GetComponent<LineRenderer>().enabled = false;
      }
      else
      {
        player.transform.GetChild(10).GetComponent<LineRenderer>().enabled = false;
      }
    }
}
