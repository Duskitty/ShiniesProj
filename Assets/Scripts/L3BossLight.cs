using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3BossLight : MonoBehaviour
{
  public SunlightTrigger[] sunPatches;

  // Player Variables
  private GameObject player;
  private Collider2D lightHitObj;
  private Collider2D fireHitObj;
  private Collider2D iceHitObj;
  private bool inSun;
    //boss variales
    private GameObject boss;


  // Start is called before the first frame update
  void Start()
  {
    player = GameObject.Find("Player");
    boss = GameObject.FindWithTag("Boss");
  }

  void Update()
  {
    inSun = checkInSun();
    player.transform.GetChild(11).GetComponent<castBeam>().clearBeams(null);

    if (inSun)
    {
      lightHitObj = player.transform.GetChild(10).GetComponent<castBeam>().reflect();
    }
    else
    {
      lightHitObj = player.transform.GetChild(10).GetComponent<castBeam>().getPlayerHitCollider();
    }

  }

  private bool checkInSun()
  {
    for (int i = 0; i < sunPatches.Length; i++)
    {
      if (sunPatches[i].inSunlight)
      {
        return true;
      }
    }
    return false;
  }
}
