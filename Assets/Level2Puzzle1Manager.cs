using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Puzzle1Manager : MonoBehaviour
{
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
  private GameObject pyramid0;
  private Transform pyramid0HitPoint;
  private Transform pyramid0RaySpawn;
  private Transform pyramid0LightSpawn;
  private LineRenderer pyramid0Beam;
  private RaycastHit2D p0Hit;
  private GameObject pyramid1;
  private Transform pyramid1HitPoint;
  private Transform pyramid1RaySpawn;
  private Transform pyramid1LightSpawn;
  private LineRenderer pyramid1Beam;
  private RaycastHit2D p1Hit;


  // Start is called before the first frame update
  void Start()
    {
      player = GameObject.Find("Player");
      playerLightSpawn = player.transform.GetChild(10);
      playerBeam = playerLightSpawn.GetComponent<LineRenderer>();
      playerBeam.enabled = false;
      playerDirection = player.GetComponent<Animator>();
      layerMask = LayerMask.GetMask("SunPatch");
      pyramid0 = GameObject.Find("pyramid0");
      pyramid0HitPoint = pyramid0.transform.GetChild(2);
      pyramid0RaySpawn = pyramid0.transform.GetChild(1);
      pyramid0LightSpawn = pyramid0.transform.GetChild(0);
      pyramid0Beam = pyramid0LightSpawn.GetComponent<LineRenderer>();
      pyramid1 = GameObject.Find("pyramid1");
      pyramid1HitPoint = pyramid1.transform.GetChild(2);
      pyramid1RaySpawn = pyramid1.transform.GetChild(1);
      pyramid1LightSpawn = pyramid1.transform.GetChild(0);
      pyramid1Beam = pyramid1LightSpawn.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      if (GameObject.Find("SunPatch00").GetComponent<SunlightTrigger>().inSunlight)
      {
        if (playerDirection.GetBool("isMoving"))
        {
          pyramid0Beam.enabled = false;
          pyramid1Beam.enabled = false;
        }

        if (playerDirection.GetBool("isIdleUp"))
        {
          playerHitPoint = player.transform.GetChild(5);
          playerRaySpawn = player.transform.GetChild(1);
          beamDirection = playerRaySpawn.TransformDirection(Vector3.up);
        }
        else if (playerDirection.GetBool("isIdleRight"))
        {
          playerHitPoint = player.transform.GetChild(6);
          playerRaySpawn = player.transform.GetChild(2);
          beamDirection = playerRaySpawn.TransformDirection(Vector3.right);
        }
        else if (playerDirection.GetBool("isIdleDown"))
        {
          playerHitPoint = player.transform.GetChild(8);
          playerRaySpawn = player.transform.GetChild(4);
          beamDirection = playerRaySpawn.TransformDirection(Vector3.down);
        }
        else
        {
          playerHitPoint = player.transform.GetChild(7);
          playerRaySpawn = player.transform.GetChild(3);
          beamDirection = playerRaySpawn.TransformDirection(Vector3.left);
        }


        playerHit = Physics2D.Raycast(playerRaySpawn.position, beamDirection, 50.0f, ~layerMask);
        Debug.DrawRay(playerRaySpawn.position, beamDirection);

        if (playerHit.collider != null)
        {
          playerHitPoint.position = playerHit.point;
          playerBeam.SetPosition(0, playerLightSpawn.position);
          playerBeam.SetPosition(1, playerHitPoint.position);
          playerBeam.enabled = true;

          if (playerHit.collider.name == pyramid0.name)
          {
            p0Hit = Physics2D.Raycast(pyramid0RaySpawn.position, pyramid0RaySpawn.TransformDirection(Vector3.up), 50.0f, ~layerMask);
            pyramid0HitPoint.position = p0Hit.point;
            pyramid0Beam.SetPosition(0, pyramid0LightSpawn.position);
            pyramid0Beam.SetPosition(1, pyramid0HitPoint.position);
            pyramid0Beam.enabled = true;
            p1Hit = Physics2D.Raycast(pyramid1RaySpawn.position, pyramid1RaySpawn.TransformDirection(Vector3.left), 50.0f, ~layerMask);
            pyramid1HitPoint.position = p1Hit.point;
            pyramid1Beam.SetPosition(0, pyramid1LightSpawn.position);
            pyramid1Beam.SetPosition(1, pyramid1HitPoint.position);
            pyramid1Beam.enabled = true;
          }

        }
      }
      else
      {
        pyramid0Beam.enabled = false;
        pyramid1Beam.enabled = false;
        playerBeam.enabled = false;
      }
    }
}
