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
    private RaycastHit2D playerHit;

    // Object Variables
    public GameObject[] reflectObjs;
    private int[] objBeamDirections;
    private LineRenderer[] objBeams;
    private Transform[] objLightSpawns;
    private Transform[] objHitPoints;
    private Transform[] objRaySpawns;

    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("Player");
      playerLightSpawn = player.transform.GetChild(0);
      playerBeam = playerLightSpawn.GetComponent<LineRenderer>();
      playerBeam.enabled = false;
      playerDirection = player.GetComponent<Animator>();

      objBeams = new LineRenderer[reflectObjs.Length];
      objLightSpawns = new Transform[reflectObjs.Length];
      objHitPoints = new Transform[reflectObjs.Length];
      objRaySpawns = new Transform[reflectObjs.Length];
      objBeamDirections = new int[reflectObjs.Length];

      for(int i = 0; i < reflectObjs.Length; i++)
      {
        objLightSpawns[i] = reflectObjs[i].transform.GetChild(0);
        objBeams[i] = objLightSpawns[i].GetComponent<LineRenderer>();
      }
    }

    // Update is called once per frame
    void Update()
    {
      if (checkInSunlight())
      {
        if (playerDirection.GetBool("isUp"))
        {
          playerHitPoint = player.transform.GetChild(2);
          playerRaySpawn = player.transform.GetChild(1);
          beamDirection = playerRaySpawn.TransformDirection(Vector3.up);
        }
        else if (playerDirection.GetBool("isRight"))
        {
          playerHitPoint = player.transform.GetChild(4);
          playerRaySpawn = player.transform.GetChild(3);
          beamDirection = playerRaySpawn.TransformDirection(Vector3.right);
        }
        else if (playerDirection.GetBool("isDown"))
        {
          playerHitPoint = player.transform.GetChild(8);
          playerRaySpawn = player.transform.GetChild(7);
          beamDirection = playerRaySpawn.TransformDirection(Vector3.down);
        }
        else
        {
          playerHitPoint = player.transform.GetChild(6);
          playerRaySpawn = player.transform.GetChild(5);
          beamDirection = playerRaySpawn.TransformDirection(Vector3.left);
        }

        playerHit = Physics2D.Raycast(playerRaySpawn.position, beamDirection);
        Debug.DrawRay(playerRaySpawn.position, beamDirection);

        if (playerHit.collider != null)
        {
          playerHitPoint.position = playerHit.point;
          playerBeam.SetPosition(0, playerLightSpawn.position);
          playerBeam.SetPosition(1, playerHitPoint.position);
          playerBeam.enabled = true;
        }
        //Debug.Log("in sun");
      }
      else
      {
        playerBeam.enabled = false;
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
