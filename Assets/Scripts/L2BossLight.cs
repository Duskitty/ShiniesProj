using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2BossLight : MonoBehaviour
{
  public SunlightTrigger[] sunPatches;

  // Player Variables
  private GameObject player;
  private Collider2D lightHitObj;
  private Collider2D fireHitObj;
  private bool inSun;


  // Start is called before the first frame update
  void Start()
  {
    player = GameObject.Find("Player");
  }

  void Update()
  {
    inSun = checkInSun();
    player.transform.GetChild(10).GetComponent<castBeam>().clearBeams(null);
    fireHitObj = player.transform.GetChild(10).GetComponent<castBeam>().getBossColliderFire();
    Debug.Log(fireHitObj);

    if (inSun)
    {
      lightHitObj = player.transform.GetChild(10).GetComponent<castBeam>().reflect();
    }
    else
    {
      lightHitObj = player.transform.GetChild(10).GetComponent<castBeam>().getPlayerHitCollider();
    }

    // if the boss is hit by light, make sure the boss has the Boss tag
    if (lightHitObj != null && lightHitObj.tag == "Boss")
    {
      // insert code for how the boss reacts to light
    }

    // if the boss is hit by fire
    if (fireHitObj != null)
    {
      // insert code for how the boss reacts to fire
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
