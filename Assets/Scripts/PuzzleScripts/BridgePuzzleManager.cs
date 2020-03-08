using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //private LayerMask patches;

    // Object Variables
    public GameObject[] reflectObjs;
    //private int[] objBeamDirections; 
    //private LineRenderer[] objBeams;
    //private Transform[] objLightSpawns;
    //private Transform[] objHitPoints;
    //private Transform[] objRaySpawns;

    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("Player");
      playerLightSpawn = player.transform.GetChild(10);
      playerBeam = playerLightSpawn.GetComponent<LineRenderer>();
      playerBeam.enabled = false;
      playerDirection = player.GetComponent<Animator>();
      layerMask = LayerMask.GetMask("SunPatch");

      //objBeams = new LineRenderer[reflectObjs.Length];
      //objLightSpawns = new Transform[reflectObjs.Length];
      //objHitPoints = new Transform[reflectObjs.Length];
      //objRaySpawns = new Transform[reflectObjs.Length];
      //objBeamDirections = new int[reflectObjs.Length];

    /*for(int i = 0; i < reflectObjs.Length; i++)
    {
      objLightSpawns[i] = reflectObjs[i].transform.GetChild(0);
      objBeams[i] = objLightSpawns[i].GetComponent<LineRenderer>();
    }*/
    }

    // Update is called once per frame
    void Update()
    {
      if (checkInSunlight())
      {

        if (playerDirection.GetBool("isMoving"))
        {
          Debug.Log("moving");
          for (int i = 0; i < reflectObjs.Length; i++)
          {
            reflectObjs[i].transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
          }
          return;
        }

        if (playerDirection.GetBool("isIdleUp"))
        {
          playerHitPoint = player.transform.GetChild(5);
          playerRaySpawn = player.transform.GetChild(1);
          beamDirection = playerRaySpawn.TransformDirection(Vector3.up);
          beamDirectionNum = 3;
          //Debug.Log("player up");
        }
        else if (playerDirection.GetBool("isIdleRight"))
        {
          playerHitPoint = player.transform.GetChild(6);
          playerRaySpawn = player.transform.GetChild(2);
          beamDirection = playerRaySpawn.TransformDirection(Vector3.right);
          beamDirectionNum = 2;
          //Debug.Log("player right");
        }
        else if (playerDirection.GetBool("isIdleDown"))
        {
          playerHitPoint = player.transform.GetChild(8);
          playerRaySpawn = player.transform.GetChild(4);
          beamDirection = playerRaySpawn.TransformDirection(Vector3.down);
          beamDirectionNum = 1;
          //Debug.Log("player down");
        }
        else
        {
          playerHitPoint = player.transform.GetChild(7);
          playerRaySpawn = player.transform.GetChild(3);
          beamDirection = playerRaySpawn.TransformDirection(Vector3.left);
          beamDirectionNum = 0;
          //Debug.Log("player left");
        }
        

        playerHit = Physics2D.Raycast(playerRaySpawn.position, beamDirection, 50.0f, ~layerMask);
        Debug.DrawRay(playerRaySpawn.position, beamDirection);

        if (playerHit.collider != null)
        {
          playerHitPoint.position = playerHit.point;
          playerBeam.SetPosition(0, playerLightSpawn.position);
          playerBeam.SetPosition(1, playerHitPoint.position);
          playerBeam.enabled = true;

          reflect(playerHit.collider.name, beamDirectionNum);
          
        }
        //Debug.Log("in sun");
      }
      else
      {
        playerBeam.enabled = false;
        for(int i = 0; i < reflectObjs.Length; i++)
        {
          reflectObjs[i].transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
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

    private bool checkObjHit(string hitObjName)
    {
      for(int i = 0; i < reflectObjs.Length; i++)
      {
        if(reflectObjs[i].name == hitObjName)
        {
          return true;
        }
      }
      return false;
    }

  void reflect(string objectHitName, int direction)
  {
    //Debug.Log("Name: " + objectHitName + " Direction: " + direction);
    // 0 is right, 1 is up, 2 is left, 3 is down
    Transform hitObjRaySpawn;
    Transform hitObjHitPoint;
    Vector3 directionToCast;
    GameObject objectHit;
    Transform hitObjLightSpawn;
    LineRenderer hitObjBeam;
    RaycastHit2D objRayHit;

    objectHit = GameObject.Find(objectHitName);

    if(objectHit.transform.tag == "enemy")
    {
      Debug.Log("Enemy Hit");
      objectHit.GetComponent<StunEnemy>().stun(objectHit);
      //StunEnemy stunEnemy = new StunEnemy();
      //stunEnemy.stun(objectHit);
      //objectHit.Stun.stunEnemy();
    }

    if (checkObjHit(objectHitName))
    {
      
      hitObjLightSpawn = objectHit.transform.GetChild(0);  
      hitObjBeam = hitObjLightSpawn.GetComponent<LineRenderer>();

      /*if(playerHit.collider.name != currentHitObjects[0].name)
      {
        for(int i = 0; i < currHitObjIndex; i++)
        {
          currentHitObjects[i].transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
        }
      }*/

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

      if(objRayHit.collider != null)
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
