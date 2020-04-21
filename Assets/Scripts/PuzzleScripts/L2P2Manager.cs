using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Pathfinding
{
  public class L2P2Manager : MonoBehaviour
  {
    private LayerMask layerMask;
    private LineRenderer[] hittableObjBeams;

    private GameObject pyramid0;
    private LineRenderer pyramid0Beam;
    private Collider2D p0Hit;
    private string currP0Direction;

    private GameObject pyramid1;
    private LineRenderer pyramid1Beam;
    private Collider2D p1Hit;
    private string currP1Direction;

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
    private Animator playerDirection;
    private LineRenderer playerBeam;
    private GameObject mirage;
    private Animator mirageAnimator;

    private GameObject snake;

    private bool inSun;

    // Start is called before the first frame update
    void Start()
    {
      layerMask = LayerMask.GetMask("SunPatch");
      pyramid0 = GameObject.Find("miragePyramid00");
      pyramid0Beam = pyramid0.transform.GetChild(0).GetComponent<LineRenderer>();
      pyramid0Beam.enabled = false;
      currP0Direction = null;

      pyramid1 = GameObject.Find("miragePyramid01");
      pyramid1Beam = pyramid1.transform.GetChild(0).GetComponent<LineRenderer>();
      pyramid1Beam.enabled = false;
      currP1Direction = null;

      orb0 = GameObject.Find("mirageOrb00");
      orb0.transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;

      orb1 = GameObject.Find("mirageOrb01");
      orb1.transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;

      hittableObjBeams = new LineRenderer[2];
      hittableObjBeams[0] = pyramid0Beam;
      hittableObjBeams[1] = pyramid1Beam;

      player = GameObject.Find("Player");
      playerDirection = player.GetComponent<Animator>();
      playerBeam = player.transform.GetChild(10).GetComponent<LineRenderer>();

      mirage = GameObject.Find("Mirage");
      mirageAnimator = mirage.GetComponent<Animator>();

      snake = GameObject.Find("EnemyTrack");
    }

    // Update is called once per frame
    void Update()
    {
      inSun = GameObject.Find("SunPatch01").GetComponent<SunlightTrigger>().inSunlight;
      player.transform.GetChild(10).GetComponent<castBeam>().clearBeams(hittableObjBeams);

      if (inSun)
      {
        playerHitObj = player.transform.GetChild(10).GetComponent<castBeam>().reflect();
      }
      else
      {
        playerHitObj = player.transform.GetChild(10).GetComponent<castBeam>().getPlayerHitCollider();
      }

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
        else if (playerHitObj.name == pyramid0.name && playerDirection.GetBool("isIdleUp") && !pyramid0Beam.enabled)
        {
          currP0Direction = "right";
          p0Hit = setPyramidLight(pyramid0, pyramid0.transform.GetChild(1).TransformDirection(Vector3.right), 2, 1);
        }
        else if (playerHitObj.name == pyramid0.name && playerDirection.GetBool("isIdleLeft") && !pyramid0Beam.enabled)
        {
          currP0Direction = "down";
          p0Hit = setPyramidLight(pyramid0, pyramid0.transform.GetChild(1).TransformDirection(Vector3.down), 4, 3);
        }
        else if (playerHitObj.name == pyramid0.name && (playerDirection.GetBool("isIdleRight") || playerDirection.GetBool("isIdleDown")))
        {
          currP0Direction = null;
          p0Hit = null;
        }
        else if (playerHitObj.name == pyramid1.name && playerDirection.GetBool("isIdleUp") && !pyramid1Beam.enabled)
        {
          currP1Direction = "left";
          p1Hit = setPyramidLight(pyramid1, pyramid1.transform.GetChild(1).TransformDirection(Vector3.left), 2, 1);
        }
        else if (playerHitObj.name == pyramid1.name && playerDirection.GetBool("isIdleRight") && !pyramid1Beam.enabled)
        {
          currP1Direction = "down";
          p1Hit = setPyramidLight(pyramid1, pyramid1.transform.GetChild(1).TransformDirection(Vector3.down), 4, 3);
        }
        else if (playerHitObj.name == pyramid1.name && (playerDirection.GetBool("isIdleLeft") || playerDirection.GetBool("isIdleDown")))
        {
          currP1Direction = null;
          p1Hit = null;
        }
      }

      if ((orb0Hit != null && orb0Hit.name == pyramid0.name) || (orb1Hit != null && orb1Hit.name == pyramid0.name))
      {
        p0Hit = setPyramidLight(pyramid0, pyramid0.transform.GetChild(1).TransformDirection(Vector3.right), 2, 1);
      }
      if ((orb0Hit != null && orb0Hit.name == pyramid1.name) || (orb1Hit != null && orb1Hit.name == pyramid1.name))
      {
        p1Hit = setPyramidLight(pyramid1, pyramid1.transform.GetChild(1).TransformDirection(Vector3.left), 2, 1);
      }

      if (orb0Hit != null && orb1Hit != null && playerHitObj != null)
      {
        if (orb0Hit.name != pyramid0.name && orb1Hit.name != pyramid0.name && playerHitObj.GetComponent<BoxCollider2D>().name == pyramid0.name)
        {
          pyramid0Beam.enabled = false;
          p0Hit = null;
          currP0Direction = null;
        }
        if (orb0Hit.name != pyramid1.name && orb1Hit.name != pyramid1.name && playerHitObj.GetComponent<BoxCollider2D>().name == pyramid1.name)
        {
          pyramid1Beam.enabled = false;
          p1Hit = null;
          currP1Direction = null;
        }
      }


      if (orb0.transform.GetChild(0).GetComponent<LineRenderer>().enabled)
      {
        orb0Hit = setOrbLight(orb0);
      }
      if (orb1.transform.GetChild(0).GetComponent<LineRenderer>().enabled)
      {
        orb1Hit = setOrbLight(orb1);
      }

      if (pyramid0Beam.enabled && currP0Direction == "right")
      {
        p0Hit = setPyramidLight(pyramid0, pyramid0.transform.GetChild(1).TransformDirection(Vector3.right), 2, 1);
      }
      else if (pyramid0Beam.enabled && currP0Direction == "down")
      {
        p0Hit = setPyramidLight(pyramid0, pyramid0.transform.GetChild(1).TransformDirection(Vector3.down), 4, 3);
      }
      if (pyramid1Beam.enabled && currP1Direction == "left")
      {
        p1Hit = setPyramidLight(pyramid1, pyramid1.transform.GetChild(1).TransformDirection(Vector3.left), 2, 1);
      }
      if (pyramid1Beam.enabled && currP1Direction == "down")
      {
        p1Hit = setPyramidLight(pyramid1, pyramid1.transform.GetChild(1).TransformDirection(Vector3.down), 4, 3);
      }

      if (p0Hit != null && p0Hit.GetComponent<BoxCollider2D>() != null && p0Hit.GetComponent<BoxCollider2D>().name == pyramid1.name)
      {
        p1Hit = setPyramidLight(pyramid1, pyramid1.transform.GetChild(1).TransformDirection(Vector3.down), 4, 3);
      }
      if (p1Hit != null && p1Hit.GetComponent<BoxCollider2D>() != null && p1Hit.GetComponent<BoxCollider2D>().name == pyramid0.name)
      {
        p0Hit = setPyramidLight(pyramid0, pyramid0.transform.GetChild(1).TransformDirection(Vector3.down), 4, 3);
      }

      if (mirage != null)
      {
        // if only one light beam hits the mirage then set the mirage animator to 1 hit
        if ((playerHitObj != null && playerHitObj.name == mirage.name && (p0Hit == null || p0Hit.name != mirage.name) && (p1Hit == null || p1Hit.name != mirage.name))
            || ((playerHitObj == null || playerHitObj.name != mirage.name) && p0Hit != null && p0Hit.name == mirage.name && (p1Hit == null || p1Hit.name != mirage.name))
            || ((playerHitObj == null || playerHitObj.name != mirage.name) && (p0Hit == null || p0Hit.name != mirage.name) && p1Hit != null && p1Hit.name == mirage.name))
        {
          mirageAnimator.SetInteger("numHits", 1);
        }
        // If two of the beams hit the mirage then set the animator to 2 hits
        else if ((playerHitObj != null && playerHitObj.name == mirage.name && p0Hit != null && p0Hit.name == mirage.name && (p1Hit == null || p1Hit.name != mirage.name))
                || (playerHitObj != null && playerHitObj.name == mirage.name && p1Hit != null && p1Hit.name == mirage.name && (p0Hit == null || p0Hit.name != mirage.name))
                || (p0Hit != null && p0Hit.name == mirage.name && p1Hit != null & p1Hit.name == mirage.name && (playerHitObj == null || playerHitObj.name != mirage.name)))
        {
          mirageAnimator.SetInteger("numHits", 2);
        }
        // if all three beams hit the mirage then destroy it
        else if (playerHitObj != null && playerHitObj.name == mirage.name && p0Hit != null && p0Hit.name == mirage.name && p1Hit != null && p1Hit.name == mirage.name)
        {
          GameObject.Find("SoundManager").GetComponent<SoundManager>().playSound("mirage");
          Destroy(mirage);
          // activate enemy and the collider for the fire gem
          GameObject.Find("FireGem").GetComponent<CircleCollider2D>().enabled = true;
          GameObject.Find("FireSign").GetComponent<BoxCollider2D>().enabled = true;
          snake.GetComponent<AIPath>().enabled = true;
        }
        else
        {
          mirageAnimator.SetInteger("numHits", 0);
        }
      }
      /*if (!playerBeam.enabled)
      {
        if((orb0Hit == null || orb0Hit.GetComponent<BoxCollider2D>().name != pyramid0.name) && (orb1Hit == null || orb1Hit.GetComponent<BoxCollider2D>().name != pyramid0.name))
        {
          pyramid0Beam.enabled = false;
        }
        if ((orb0Hit == null || orb0Hit.GetComponent<BoxCollider2D>().name != pyramid1.name) && (orb1Hit == null || orb1Hit.GetComponent<BoxCollider2D>().name != pyramid1.name))
        {
          pyramid1Beam.enabled = false;
        }

        //playerBeam.enabled = false;
      }*/
      if(playerHitObj != null && playerHitObj.tag == "enemy")
      {
        if (playerHitObj.name == snake.transform.GetChild(0).name
        || p0Hit != null && p0Hit.GetComponent<CircleCollider2D>().name == snake.transform.GetChild(0).name ||
        p1Hit != null && p1Hit.GetComponent<CircleCollider2D>().name == snake.transform.GetChild(0).name)
        {
          snake.GetComponent<StunEnemy>().stun(snake);
        }
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
      orb.GetComponent<Animator>().SetBool("isLit", true);

      return orbHit.collider;
    }

    private Collider2D setPyramidLight(GameObject pyramid, Vector3 direction, int hitPoint, int raySpawn)
    {
      //Debug.Log("here");
      pyramidHitPoint = pyramid.transform.GetChild(hitPoint);
      pyramidRaySpawn = pyramid.transform.GetChild(raySpawn);
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
}
