using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Pathfinding
{
  //using Pathfinding.RVO;
  using Pathfinding.Util;

  public class BridgePuzzleManager : MonoBehaviour
  {
    public SunlightTrigger[] sunPatches;

    // Player Variables
    private GameObject player;
    private Animator playerDirection;
    private Transform playerLightSpawn;
    private LineRenderer playerBeam;
    private Transform playerHitPoint;
    private Transform playerRaySpawn;
    private Vector3 beamDirection;
    private int beamDirectionNum;
    private RaycastHit2D playerHit;
    private LayerMask layerMask;
    private Collider2D hitCollider;

    // Object Variables
    public GameObject[] reflectObjs;
    private LineRenderer[] hittableObjBeams;

    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("Player");
      playerLightSpawn = player.transform.GetChild(10);
      playerBeam = playerLightSpawn.GetComponent<LineRenderer>();
      playerBeam.enabled = false;
      playerDirection = player.GetComponent<Animator>();
      layerMask = LayerMask.GetMask("SunPatch");
      hittableObjBeams = new LineRenderer[reflectObjs.Length];
      for (int i = 0; i < hittableObjBeams.Length; i++)
      {
        hittableObjBeams[i] = reflectObjs[i].transform.GetChild(0).GetComponent<LineRenderer>();
      }
    }

    // Update is called once per frame
    void Update()
    {
      player.transform.GetChild(10).GetComponent<castBeam>().clearBeams(hittableObjBeams);

      if (checkInSunlight())
      {
        if (playerDirection.GetBool("isIdleUp"))
        {
          beamDirectionNum = 3;
        }
        else if (playerDirection.GetBool("isIdleRight"))
        {
          beamDirectionNum = 2;
        }
        else if (playerDirection.GetBool("isIdleDown"))
        {
          beamDirectionNum = 1;
        }
        else
        {
          beamDirectionNum = 0;
        }
        hitCollider = player.transform.GetChild(10).GetComponent<castBeam>().reflect();

        if(hitCollider.name != "bridgeRock01")
        {
          hittableObjBeams[1].enabled = false;
        }
        if (hitCollider.name != "bridgeRock06")
        {
          hittableObjBeams[6].enabled = false;
        }

        if (hitCollider != null)
        {
          reflect(hitCollider.name, beamDirectionNum);
        }
        

      }
      else
      {
        playerBeam.enabled = false;
        for (int i = 0; i < reflectObjs.Length; i++)
        {
          reflectObjs[i].transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
        }
      }
    }

    private bool checkInSunlight()
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

    private bool checkObjHit(string hitObjName)
    {
      for (int i = 0; i < reflectObjs.Length; i++)
      {
        if (reflectObjs[i].name == hitObjName)
        {
          return true;
        }
      }
      return false;
    }

    void reflect(string objectHitName, int direction)
    {
      // 0 is right, 1 is up, 2 is left, 3 is down
      Transform hitObjRaySpawn;
      Transform hitObjHitPoint;
      Vector3 directionToCast;
      GameObject objectHit;
      Transform hitObjLightSpawn;
      LineRenderer hitObjBeam;
      RaycastHit2D objRayHit;
    
      objectHit = GameObject.Find(objectHitName);
      Debug.Log(objectHit.name);
      if (objectHit.transform.tag == "enemy" && objectHit.name != "BreakableRock")
      {
        //Debug.Log("Enemy Hit");
        objectHit.GetComponent<StunEnemy>().stun(objectHit); 
      }

      if (checkObjHit(objectHitName))
      {
        player.transform.GetChild(10).GetComponent<castBeam>().clearBeams(hittableObjBeams);
        hitObjLightSpawn = objectHit.transform.GetChild(0);
        hitObjBeam = hitObjLightSpawn.GetComponent<LineRenderer>();

        // if beam comes from the right then the next beam will go up
        if (direction == 0)
        {
          hitObjRaySpawn = objectHit.transform.GetChild(1);
          hitObjHitPoint = objectHit.transform.GetChild(2);
          directionToCast = hitObjRaySpawn.TransformDirection(Vector3.up);
          direction = 3;
        }
        // if beam comes from the top then the next beam will go left
        else if (direction == 1)
        {
          hitObjRaySpawn = objectHit.transform.GetChild(7);
          hitObjHitPoint = objectHit.transform.GetChild(8);
          directionToCast = hitObjRaySpawn.TransformDirection(Vector3.left);
          direction = 0;
        }
        // if beam comes from the left then the next beam will go down
        else if (direction == 2)
        {
          hitObjRaySpawn = objectHit.transform.GetChild(5);
          hitObjHitPoint = objectHit.transform.GetChild(6);
          directionToCast = hitObjRaySpawn.TransformDirection(Vector3.down);
          direction = 1;
        }
        // if beam comes from the bottom then the next beam will go right
        else
        {
          hitObjRaySpawn = objectHit.transform.GetChild(3);
          hitObjHitPoint = objectHit.transform.GetChild(4);
          directionToCast = hitObjRaySpawn.TransformDirection(Vector3.right);
          direction = 2;
        }

        objRayHit = Physics2D.Raycast(hitObjRaySpawn.position, directionToCast, 50.0f, ~layerMask);
        Debug.DrawRay(hitObjRaySpawn.position, directionToCast);

        if (objRayHit.collider != null)
        {
          hitObjHitPoint.position = objRayHit.point;
          hitObjBeam.SetPosition(0, hitObjLightSpawn.position);
          hitObjBeam.SetPosition(1, hitObjHitPoint.position);
          hitObjBeam.enabled = true;

          reflect(objRayHit.collider.name, direction);
        }
      }
    }
  }
}
