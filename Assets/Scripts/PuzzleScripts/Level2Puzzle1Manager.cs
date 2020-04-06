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

  public bool pressed;

  private SpriteRenderer orb;

  private Collider2D playerHitObj;

  private bool inSun;
  private bool reflectGem;
  private bool fireGem;
  private int charges;


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
    }

    // Update is called once per frame
    void Update()
    {
      inSun = GameObject.Find("SunPatch00").GetComponent<SunlightTrigger>().inSunlight;
      pressed = player.GetComponent<BeamButton>().isPressed();
      reflectGem = player.GetComponent<GemPick>().returnReflectGem();
      fireGem = player.GetComponent<GemPick>().returnFireGem();
      charges = GameControlScript.charges;

      if ((inSun && !pressed) || (inSun && pressed && reflectGem) || (!inSun && pressed && reflectGem))
      {
        playerHitObj = player.transform.GetChild(10).GetComponent<castBeam>().reflect(hittableObjBeams);

        if (playerHitObj != null && playerHitObj.name == pyramid0.name && (playerDirection.GetBool("isIdleRight") || playerDirection.GetBool("isRight")))
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
          GameObject.Find("Stairs").GetComponent<SpriteRenderer>().enabled = true;
          GameObject.Find("Stairs").GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (playerHitObj != null && playerHitObj.name == pyramid0.name && (playerDirection.GetBool("isIdleDown") || playerDirection.GetBool("isDown")))
        {
          pyramid0RaySpawn = pyramid0.transform.GetChild(3);
          p0Hit = Physics2D.Raycast(pyramid0RaySpawn.position, pyramid0RaySpawn.TransformDirection(Vector3.left), 50.0f, ~layerMask);
          pyramid0HitPoint.position = p0Hit.point;
          pyramid0Beam.SetPosition(0, pyramid0LightSpawn.position);
          pyramid0Beam.SetPosition(1, pyramid0HitPoint.position);
          pyramid0Beam.enabled = true;
        }
        else if (playerHitObj != null && playerHitObj.name == pyramid1.name)
        {
          pyramid1RaySpawn = pyramid1.transform.GetChild(1);
          p1Hit = Physics2D.Raycast(pyramid1RaySpawn.position, pyramid1RaySpawn.TransformDirection(Vector3.left), 50.0f, ~layerMask);
          pyramid1HitPoint.position = p1Hit.point;
          pyramid1Beam.SetPosition(0, pyramid1LightSpawn.position);
          pyramid1Beam.SetPosition(1, pyramid1HitPoint.position);
          pyramid1Beam.enabled = true;
          orb.GetComponent<Animator>().SetBool("isLit", true);
          // Activate stairs
          GameObject.Find("Stairs").GetComponent<SpriteRenderer>().enabled = true;
          GameObject.Find("Stairs").GetComponent<BoxCollider2D>().enabled = false;
        }
       }
      else
      {
        //playerBeam.enabled = false;
        pyramid1Beam.enabled = false;
        pyramid0Beam.enabled = false;
      }
    }
 
}
