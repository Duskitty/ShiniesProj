using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1Boss : MonoBehaviour
{
  public SunlightTrigger[] sunPatches;

  private GameObject player;
  private Collider2D hitCollider;
  private GameObject hitObj;
  
  // Start is called before the first frame update
  void Start()
    {
      player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
      if (checkInSunlight())
      {
        Debug.Log("in sun");
        hitCollider = player.transform.GetChild(10).GetComponent<castBeam>().reflect(null);

        if (hitCollider != null)
        {
          hitObj = GameObject.Find(hitCollider.name);

          if(hitObj.tag == "Boss")
          {
            // do something when it hits the boss
          }
          else if(hitObj.tag == "enemy")
          {
            //hitObj.GetComponent<StunEnemy>().stun(hitObj);
          }
        }
      }
    }

    private bool checkInSunlight()
    { 
      for(int i = 0; i < sunPatches.Length; i++)
      {
        if (sunPatches[i].inSunlight)
        {
          return true;
        }
      }

      return false;
    }
}
