using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2P2Manager : MonoBehaviour
{
  public Sprite litOrb;
  private LayerMask layerMask;
  private LineRenderer[] hittableObjBeams;

  private GameObject pyramid0;
  private LineRenderer pyramid0Beam;
  private Collider2D p0Hit;

  private GameObject pyramid1;
  private LineRenderer pyramid1Beam;
  private Collider2D p1Hit;

  private GameObject pyramid;
  private Transform pyramidHitPoint;
  private Transform pyramidRaySpawn;
  private Transform pyramidLightSpawn;
  private LineRenderer pyramidBeam;
  private RaycastHit2D pHit;
  private GameObject orb0;
  private Collider2D orb0Hit;
  private GameObject orb1;
  private Collider2D orb1Hit;
  private GameObject orb;
  private Transform orbHitPoint;
  private Transform orbRaySpawn;
  private Transform orbLightSpawn;
  private LineRenderer orbBeam;
  private RaycastHit2D orbHit;
  private Collider2D playerHitObj;
  private GameObject player;

  // Start is called before the first frame update
  void Start()
  {
    layerMask = LayerMask.GetMask("SunPatch");
    pyramid0 = GameObject.Find("miragePyramid00");
    pyramid0Beam = pyramid0.transform.GetChild(0).GetComponent<LineRenderer>();
    pyramid0Beam.enabled = false;

    pyramid1 = GameObject.Find("miragePyramid01");
    pyramid1Beam = pyramid1.transform.GetChild(0).GetComponent<LineRenderer>();
    pyramid1Beam.enabled = false;

    orb0 = GameObject.Find("mirageOrb00");
    orb0.transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;

    orb1 = GameObject.Find("mirageOrb01");
    orb1.transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;

    hittableObjBeams = new LineRenderer[2];
    hittableObjBeams[0] = pyramid0Beam;
    hittableObjBeams[1] = pyramid1Beam;

    player = GameObject.Find("Player");
  }

    // Update is called once per frame
    void Update()
    {
      if (GameObject.Find("SunPatch01").GetComponent<SunlightTrigger>().inSunlight /* && shield set to light*/)
      {
        player.transform.GetChild(10).GetComponent<castBeam>().reflect(hittableObjBeams);
        player.transform.GetChild(10).GetComponent<castBeam>().disableFire();
      }
      else if (GameObject.Find("SunPatch01").GetComponent<SunlightTrigger>().inSunlight /* && shield set to fire*/)
      {
        //cast fire and burn things
        player.transform.GetChild(10).GetComponent<castBeam>().castFire();
        player.transform.GetChild(10).GetComponent<castBeam>().disableLight();
      }
      else if (!GameObject.Find("SunPatch01").GetComponent<SunlightTrigger>().inSunlight /* && shield set to light && button pressed*/)
      {
        playerHitObj = player.transform.GetChild(10).GetComponent<castBeam>().reflect(hittableObjBeams);

        if (playerHitObj != null)
        {
          if (playerHitObj.name == orb0.name)
          {
            orb0Hit = setOrbLight(orb0);
          }
          else if (playerHitObj.name == orb1.name)
          {
            orb1Hit = setOrbLight(orb1);
          }
          else if (playerHitObj.name == pyramid0.name)
          {
            p0Hit = setPyramidLight(pyramid0, pyramid0.transform.GetChild(1).TransformDirection(Vector3.right));
          }
          else if (playerHitObj.name == pyramid1.name)
          {
            p1Hit = setPyramidLight(pyramid1, pyramid1.transform.GetChild(1).TransformDirection(Vector3.left));
          }
        }
      }
      else if (!GameObject.Find("SunPatch01").GetComponent<SunlightTrigger>().inSunlight /* && shield set to fire && button pressed*/)
      {
        // cast fire
      }
      else
      {
        player.transform.GetChild(10).GetComponent<castBeam>().disableLight();
        pyramid1Beam.enabled = false;
        pyramid0Beam.enabled = false;
      }

      if(orb0Hit.name == pyramid0.name || orb1Hit.name == pyramid0.name)
      {
        p0Hit = setPyramidLight(pyramid0, pyramid0.transform.GetChild(1).TransformDirection(Vector3.right));
      }
      if(orb0Hit.name == pyramid1.name || orb1Hit.name == pyramid1.name)
      {
        p1Hit = setPyramidLight(pyramid1, pyramid1.transform.GetChild(1).TransformDirection(Vector3.left));
      }
      if(orb0Hit.name != pyramid0.name && orb1Hit.name != pyramid0.name && playerHitObj.collider.name == pyramid0.name)
      {
        pyramid0Beam.enabled = false;
      }
      if (orb0Hit.name != pyramid1.name && orb1Hit.name != pyramid1.name && playerHitObj.collider.name == pyramid1.name)
      {
        pyramid1Beam.enabled = false;
      }

    if (orb0.transform.GetChild(0).GetComponent<LineRenderer>().enabled)
      {
        orb0Hit = setOrbLight(orb0);
      }
      if (orb1.transform.GetChild(0).GetComponent<LineRenderer>().enabled)
      {
        orb1Hit = setOrbLight(orb1);
      }
      if (pyramid0Beam.enabled)
      {
        p0Hit = setPyramidLight(pyramid0, pyramid0.transform.GetChild(1).TransformDirection(Vector3.right));
      }
      if (pyramid1Beam.enabled)
      {
        p1Hit = setPyramidLight(pyramid1, pyramid1.transform.GetChild(1).TransformDirection(Vector3.left));
      }
    }

  private Collider2D setOrbLight(GameObject orb)
  {
    orbHitPoint = orb.transform.GetChild(2);
    orbRaySpawn = orb.transform.GetChild(1);
    orbLightSpawn = orb.transform.GetChild(0);
    orbBeam = orbLightSpawn.GetComponent<LineRenderer>();

    orbHit = Physics2D.Raycast(orbRaySpawn.position, orbRaySpawn.TransformDirection(Vector3.up), 50.0f, ~layerMask);
    orbHitPoint.position = orbHit.point;
    orbBeam.SetPosition(0, orbLightSpawn.position);
    orbBeam.SetPosition(1, orbHitPoint.position);

    orbBeam.enabled = true;
    orb.GetComponent<SpriteRenderer>().sprite = litOrb;

    return orbHit.collider;
  }

  private Collider2D setPyramidLight(GameObject pyramid, Vector3 direction)
  {
    //Debug.Log("here");
    pyramidHitPoint = pyramid.transform.GetChild(2);
    pyramidRaySpawn = pyramid.transform.GetChild(1);
    pyramidLightSpawn = pyramid.transform.GetChild(0);
    pyramidBeam = pyramidLightSpawn.GetComponent<LineRenderer>();

    pHit = Physics2D.Raycast(pyramidRaySpawn.position, direction, 50.0f, ~layerMask);
    pyramidHitPoint.position = pHit.point;
    pyramidBeam.SetPosition(0, pyramidLightSpawn.position);
    pyramidBeam.SetPosition(1, pyramidHitPoint.position);
    pyramidBeam.enabled = true;

    return pHit.collider;
  }
}
