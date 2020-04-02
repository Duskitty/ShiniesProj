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

  public Sprite litOrb;
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
      pyramid0RaySpawn = pyramid0.transform.GetChild(1);
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
      if (GameObject.Find("SunPatch00").GetComponent<SunlightTrigger>().inSunlight /* && shield set to light*/)
      {
        player.transform.GetChild(10).GetComponent<castBeam>().castFire();
        player.transform.GetChild(10).GetComponent<castBeam>().disableLight();
        //player.transform.GetChild(10).GetComponent<castBeam>().reflect(hittableObjBeams);
        //player.transform.GetChild(10).GetComponent<castBeam>().disableFire();
      }
      //else if (!GameObject.Find("SunPatch00").GetComponent<SunlightTrigger>().inSunlight /* && shield set to light && button pressed*/)
      /*{
        playerHitObj = player.transform.GetChild(10).GetComponent<castBeam>().reflect(hittableObjBeams);

        if (playerHitObj != null && playerHitObj.name == pyramid0.name)
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
          orb.GetComponent<Animator>.SetBool("isLit", true);
        }
      }*/
      else if (!GameObject.Find("SunPatch00").GetComponent<SunlightTrigger>().inSunlight /* && shield set to fire && button pressed*/)
      {
        player.transform.GetChild(10).GetComponent<castBeam>().castFire();
        player.transform.GetChild(10).GetComponent<castBeam>().disableLight();
      }
      else
      {
        playerBeam.enabled = false;
        pyramid1Beam.enabled = false;
        pyramid0Beam.enabled = false;
      }
    }
 
}
