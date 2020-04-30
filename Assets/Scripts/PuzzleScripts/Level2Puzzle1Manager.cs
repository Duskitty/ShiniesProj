using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Puzzle1Manager : MonoBehaviour
{
  private GameObject player;
  private LineRenderer playerBeam;
  private LayerMask layerMask;
  private RaycastHit2D playerHit;
  private Animator playerDirection;
  private LineRenderer[] hittableObjBeams;
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
  private bool inSun;
  private RaycastHit2D up;
  private RaycastHit2D down;
  private RaycastHit2D left;
  private RaycastHit2D right;

  private SpriteRenderer orb;

  private Collider2D playerHitObj;

  // Start is called before the first frame update
  void Start()
  {
    player = GameObject.Find("Player");
    playerBeam = player.transform.GetChild(10).GetComponent<LineRenderer>();
    playerBeam.enabled = false;

    playerDirection = player.GetComponent<Animator>();
    layerMask = LayerMask.GetMask("SunPatch");
    pyramid0 = GameObject.Find("pyramid0");
    pyramid0HitPoint = pyramid0.transform.GetChild(2);
    pyramid0LightSpawn = pyramid0.transform.GetChild(0);
    pyramid0Beam = pyramid0LightSpawn.GetComponent<LineRenderer>();
    pyramid1 = GameObject.Find("pyramid1");
    pyramid1HitPoint = pyramid1.transform.GetChild(2);
    pyramid1RaySpawn = pyramid1.transform.GetChild(1);
    pyramid1LightSpawn = pyramid1.transform.GetChild(0);
    pyramid1Beam = pyramid1LightSpawn.GetComponent<LineRenderer>();
    orb = GameObject.Find("orb00").GetComponent<SpriteRenderer>();
    hittableObjBeams = new LineRenderer[2];
    hittableObjBeams[0] = pyramid0Beam;
    hittableObjBeams[1] = pyramid1Beam;
    inSun = false;
  }

  // Update is called once per frame
  void Update()
  {
    inSun = GameObject.Find("SunPatch00").GetComponent<SunlightTrigger>().inSunlight;
    player.transform.GetChild(10).GetComponent<castBeam>().clearBeams(hittableObjBeams);

    up = Physics2D.Raycast(player.transform.GetChild(1).position, player.transform.GetChild(1).TransformDirection(Vector3.up), 50.0f, ~layerMask);
    down = Physics2D.Raycast(player.transform.GetChild(4).position, player.transform.GetChild(4).TransformDirection(Vector3.down), 50.0f, ~layerMask);
    left = Physics2D.Raycast(player.transform.GetChild(3).position, player.transform.GetChild(3).TransformDirection(Vector3.left), 50.0f, ~layerMask);
    right = Physics2D.Raycast(player.transform.GetChild(2).position, player.transform.GetChild(2).TransformDirection(Vector3.right), 50.0f, ~layerMask);

    if (playerDirection.GetBool("isIdleUp") || playerDirection.GetBool("isUp"))
    {
      player.transform.GetChild(10).GetComponent<castBeam>().setPlayerHitCollider(up.collider);
    }
    else if (playerDirection.GetBool("isIdleLeft") || playerDirection.GetBool("isLeft"))
    {
      player.transform.GetChild(10).GetComponent<castBeam>().setPlayerHitCollider(left.collider);
    }
    else if (playerDirection.GetBool("isIdleDown") || playerDirection.GetBool("isDown"))
    {
      player.transform.GetChild(10).GetComponent<castBeam>().setPlayerHitCollider(down.collider);
    }
    else if (playerDirection.GetBool("isIdleRight") || playerDirection.GetBool("isRight"))
    {
      player.transform.GetChild(10).GetComponent<castBeam>().setPlayerHitCollider(right.collider);
    }

    if (inSun)
    {
      playerHitObj = player.transform.GetChild(10).GetComponent<castBeam>().reflect();
    }
    else
    {
      playerHitObj = player.transform.GetChild(10).GetComponent<castBeam>().getPlayerHitCollider();
      if (playerHitObj != null && !player.transform.GetChild(10).GetComponent<LineRenderer>().enabled)
      {
        Debug.Log("pHit should be null");
        playerHitObj = null;
      }
    }
      
    if (playerHitObj != null)
    {
      if (playerHitObj.name == pyramid0.name)
      {
        if (playerDirection.GetBool("isIdleDown"))
        {
          Debug.Log("here");
          pyramid0RaySpawn = pyramid0.transform.GetChild(3);
          p0Hit = Physics2D.Raycast(pyramid0RaySpawn.position, pyramid0RaySpawn.TransformDirection(Vector3.left), 50.0f, ~layerMask);
          Debug.DrawRay(pyramid0RaySpawn.position, pyramid0RaySpawn.TransformDirection(Vector3.left));
          pyramid0HitPoint.position = p0Hit.point;
          pyramid0Beam.SetPosition(0, pyramid0LightSpawn.position);
          pyramid0Beam.SetPosition(1, pyramid0HitPoint.position);
          pyramid0Beam.enabled = true;
        }
        else if (playerDirection.GetBool("isIdleRight"))
        {
          pyramid0RaySpawn = pyramid0.transform.GetChild(1);
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
          orb.GetComponent<Animator>().SetBool("isLit", true);
          // Activate stairs
          Debug.Log("problem spot 1");
          GameObject.Find("Stairs").GetComponent<SpriteRenderer>().enabled = true;
          GameObject.Find("Stairs").GetComponent<BoxCollider2D>().enabled = false;
        }
      }
      /*else if (playerHitObj.name == pyramid0.name && playerDirection.GetBool("isIdleRight"))
      {
        pyramid0RaySpawn = pyramid0.transform.GetChild(1);
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
        orb.GetComponent<Animator>().SetBool("isLit", true);
        // Activate stairs
        //Debug.Log("problem spot 1");
        GameObject.Find("Stairs").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("Stairs").GetComponent<BoxCollider2D>().enabled = false;
      }*/
      else if (playerHitObj.name == pyramid1.name)
      {
        pyramid1RaySpawn = pyramid1.transform.GetChild(1);
        p1Hit = Physics2D.Raycast(pyramid1RaySpawn.position, pyramid1RaySpawn.TransformDirection(Vector3.left), 50.0f, ~layerMask);
        pyramid1HitPoint.position = p1Hit.point;
        pyramid1Beam.SetPosition(0, pyramid1LightSpawn.position);
        pyramid1Beam.SetPosition(1, pyramid1HitPoint.position);
        pyramid1Beam.enabled = true;
        orb.GetComponent<Animator>().SetBool("isLit", true);
        // Activate stairs
        Debug.Log("problem spot 2");
        GameObject.Find("Stairs").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("Stairs").GetComponent<BoxCollider2D>().enabled = false;
      }
    }
    if(!playerBeam.enabled)
    {
      pyramid0Beam.enabled = false;
      pyramid1Beam.enabled = false;
      //playerBeam.enabled = false;
    }
  }
}
 
