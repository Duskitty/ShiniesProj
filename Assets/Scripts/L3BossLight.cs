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
    player.transform.GetChild(10).GetComponent<castBeam>().clearBeams(null);
    fireHitObj = player.transform.GetChild(10).GetComponent<castBeam>().getBossColliderFire();
    iceHitObj = player.transform.GetChild(10).GetComponent<castBeam>().getBossColliderIce();

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
      // if the light doesnt affect the crystal boss then delete this or leave it blank
    }

    // if the boss is hit by fire
    if (fireHitObj != null)
    {
            //   if (Boss.iceAttack==true)
            // {
            boss.GetComponent<Boss>().TakeDamage();
          //  }
      // insert code for how the boss reacts to fire
    }

    // if the boss is hit with ice
    if(iceHitObj != null)
    {
            //  if (Boss.fireAttack==true)
            //  {
            boss.GetComponent<Boss>().TakeDamage();

          //  }
            // insert code for how the boss reacts to ice
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
