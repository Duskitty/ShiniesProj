using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2BossLight : MonoBehaviour
{
  public SunlightTrigger[] sunPatches;
  public GameObject[] torches;

  // Player Variables
  private GameObject player;
  private Collider2D lightHitObj;
  private Collider2D fireHitObj;
  private bool inSun;


  // Start is called before the first frame update
  void Start()
  {
    player = GameObject.Find("Player");

    for(int i = 0; i < torches.Length; i++)
    {
      torches[i].GetComponent<Animator>().SetBool("isLit", true);
    }
  }

  void Update()
  {
    inSun = checkInSun();
    player.transform.GetChild(10).GetComponent<castBeam>().clearBeams(null);

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
