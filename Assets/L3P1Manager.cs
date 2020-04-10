using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3P1Manager : MonoBehaviour
{
    private GameObject player;
    private Collider2D pHit;
    private Animator playerDirection;

    private GameObject redCrystal;
    private LineRenderer redCrystalBeam;
    private Transform rcLightSpawn;
    private Transform redCrystalRaySpawn;
    private Transform redCrystalHitPoint;
    private Vector3 redCrystalBeamDirection;
    private RaycastHit2D rcHit;
    private Vector3 rcPosMod;

    private GameObject blueCrystal;
    private LineRenderer blueCrystalBeam;
    private Transform bcLightSpawn;
    private Transform blueCrystalRaySpawn;
    private Transform blueCrystalHitPoint;
    private Vector3 blueCrystalBeamDirection;
    private RaycastHit2D bcHit;
    private Vector3 bcPosMod;

    private GameObject greenCrystal;
    private LineRenderer greenCrystalBeam;
    private Transform gcLightSpawn;
    private Transform greenCrystalRaySpawn;
    private Transform greenCrystalHitPoint;
    private Vector3 greenCrystalBeamDirection;
    private RaycastHit2D gcHit;
    private Vector3 gcPosMod;

    private LayerMask layerMask;
    private LineRenderer[] hittableObjBeams;
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("Player");
      playerDirection = player.GetComponent<Animator>();

      redCrystal = GameObject.Find("RedCrystal");
      redCrystalBeam = redCrystal.transform.GetChild(0).GetComponent<LineRenderer>();
      redCrystalHitPoint = redCrystal.transform.GetChild(5);
      rcLightSpawn = redCrystal.transform.GetChild(0);
      layerMask = LayerMask.GetMask("SunPatch");

      blueCrystal = GameObject.Find("BlueCrystal");
      blueCrystalBeam = blueCrystal.transform.GetChild(0).GetComponent<LineRenderer>();
      blueCrystalHitPoint = blueCrystal.transform.GetChild(5);
      bcLightSpawn = blueCrystal.transform.GetChild(0);

      greenCrystal = GameObject.Find("GreenCrystal");
      greenCrystalBeam = greenCrystal.transform.GetChild(0).GetComponent<LineRenderer>();
      greenCrystalHitPoint = greenCrystal.transform.GetChild(5);
      gcLightSpawn = greenCrystal.transform.GetChild(0);

      hittableObjBeams = new LineRenderer[3];
      hittableObjBeams[0] = redCrystalBeam;
      hittableObjBeams[1] = blueCrystalBeam;
      hittableObjBeams[2] = greenCrystalBeam;
    }

    // Update is called once per frame
    void Update()
    {
      if (GameObject.Find("SunPatch00").GetComponent<SunlightTrigger>().inSunlight)
      {
        pHit = player.transform.GetChild(10).GetComponent<castBeam>().reflect(hittableObjBeams);
      }
      else
      {
        pHit = null;
        player.transform.GetChild(10).GetComponent<castBeam>().disableLight();
      }

      if (pHit != null)
      {
        if(pHit.name == redCrystal.name)
        {
          if(playerDirection.GetBool("isIdleUp") || playerDirection.GetBool("isUp"))
          {
            redCrystalRaySpawn = redCrystal.transform.GetChild(1);
            redCrystalBeamDirection = redCrystalRaySpawn.TransformDirection(Vector3.up);
            rcPosMod = new Vector3(player.transform.position.x - redCrystal.transform.position.x, 0, 0);
          }
          else if (playerDirection.GetBool("isIdleRight") || playerDirection.GetBool("isRight"))
          {
            redCrystalRaySpawn = redCrystal.transform.GetChild(2);
            redCrystalBeamDirection = redCrystalRaySpawn.TransformDirection(Vector3.right);
            rcPosMod = new Vector3(0, player.transform.position.y - redCrystal.transform.position.y, 0);
          }
          else if (playerDirection.GetBool("isIdleDown") || playerDirection.GetBool("isDown"))
          {
            redCrystalRaySpawn = redCrystal.transform.GetChild(3);
            redCrystalBeamDirection = redCrystalRaySpawn.TransformDirection(Vector3.down);
            rcPosMod = new Vector3(player.transform.position.x - redCrystal.transform.position.x, 0, 0);
          }
          else if (playerDirection.GetBool("isIdleLeft") || playerDirection.GetBool("isLeft"))
          {
            redCrystalRaySpawn = redCrystal.transform.GetChild(4);
            redCrystalBeamDirection = redCrystalRaySpawn.TransformDirection(Vector3.left);
            rcPosMod = new Vector3(0, player.transform.position.y - redCrystal.transform.position.y, 0);
          }

          rcHit = Physics2D.Raycast(redCrystalRaySpawn.position + rcPosMod, redCrystalBeamDirection, 50.0f, ~layerMask);
          Debug.DrawRay(redCrystalRaySpawn.position + rcPosMod, redCrystalBeamDirection);
          
          if (rcHit != null)
          {
            redCrystalBeam.SetColors(Color.red, Color.red);
            redCrystalHitPoint.position = rcHit.point;
            redCrystalBeam.SetPosition(0, rcLightSpawn.position + rcPosMod);
            redCrystalBeam.SetPosition(1, redCrystalHitPoint.position);
            redCrystalBeam.enabled = true;

            if(rcHit.collider.name == blueCrystal.name)
            {
              blueCrystalRaySpawn = blueCrystal.transform.GetChild(1);
              blueCrystalBeamDirection = blueCrystalRaySpawn.TransformDirection(Vector3.up);
              bcPosMod = new Vector3(player.transform.position.x - blueCrystal.transform.position.x, 0, 0);
              bcHit = Physics2D.Raycast(blueCrystalRaySpawn.position + bcPosMod, blueCrystalBeamDirection, 50.0f, ~layerMask);
              Debug.DrawRay(blueCrystalRaySpawn.position + bcPosMod, blueCrystalBeamDirection);
              
              if(bcHit != null)
              {
                blueCrystalBeam.SetColors(Color.magenta, Color.magenta);
                blueCrystalHitPoint.position = bcHit.point;
                blueCrystalBeam.SetPosition(0, bcLightSpawn.position + bcPosMod);
                blueCrystalBeam.SetPosition(1, blueCrystalHitPoint.position);
                blueCrystalBeam.enabled = true;

                if (bcHit.collider.name == greenCrystal.name)
                {
                  greenCrystalRaySpawn = greenCrystal.transform.GetChild(1);
                  greenCrystalBeamDirection = greenCrystalRaySpawn.TransformDirection(Vector3.up);
                  gcPosMod = new Vector3(player.transform.position.x - greenCrystal.transform.position.x, 0, 0);
                  gcHit = Physics2D.Raycast(greenCrystalRaySpawn.position + gcPosMod, greenCrystalBeamDirection, 50.0f, ~layerMask);
                  Debug.DrawRay(greenCrystalRaySpawn.position + gcPosMod, greenCrystalBeamDirection);
                  
                  if(gcHit != null)
                  {
                    greenCrystalBeam.SetColors(Color.white, Color.white);
                    greenCrystalHitPoint.position = gcHit.point;
                    greenCrystalBeam.SetPosition(0, gcLightSpawn.position + gcPosMod);
                    greenCrystalBeam.SetPosition(1, greenCrystalHitPoint.position);
                    greenCrystalBeam.enabled = true;
                  }
                }
              }
            }
            else if(rcHit.collider.name == greenCrystal.name)
            {
              greenCrystalRaySpawn = greenCrystal.transform.GetChild(1);
              greenCrystalBeamDirection = greenCrystalRaySpawn.TransformDirection(Vector3.up);
              gcPosMod = new Vector3(player.transform.position.x - greenCrystal.transform.position.x, 0, 0);
              gcHit = Physics2D.Raycast(greenCrystalRaySpawn.position + gcPosMod, greenCrystalBeamDirection, 50.0f, ~layerMask);
              Debug.DrawRay(greenCrystalRaySpawn.position + gcPosMod, greenCrystalBeamDirection);
              if(gcHit != null)
              {
                greenCrystalBeam.SetColors(Color.yellow, Color.yellow);
                greenCrystalHitPoint.position = gcHit.point;
                greenCrystalBeam.SetPosition(0, gcLightSpawn.position + gcPosMod);
                greenCrystalBeam.SetPosition(1, greenCrystalHitPoint.position);
                greenCrystalBeam.enabled = true;
              }
            }
          }
        }

        else if (pHit.name == blueCrystal.name)
        {
          if (playerDirection.GetBool("isIdleUp") || playerDirection.GetBool("isUp"))
          {
            blueCrystalRaySpawn = blueCrystal.transform.GetChild(1);
            blueCrystalBeamDirection = blueCrystalRaySpawn.TransformDirection(Vector3.up);
            bcPosMod = new Vector3(player.transform.position.x - blueCrystal.transform.position.x, 0, 0);
          }
          else if (playerDirection.GetBool("isIdleRight") || playerDirection.GetBool("isRight"))
          {
            blueCrystalRaySpawn = blueCrystal.transform.GetChild(2);
            blueCrystalBeamDirection = blueCrystalRaySpawn.TransformDirection(Vector3.right);
            bcPosMod = new Vector3(0, player.transform.position.y - blueCrystal.transform.position.y, 0);
          }
          else if (playerDirection.GetBool("isIdleDown") || playerDirection.GetBool("isDown"))
          {
            blueCrystalRaySpawn = blueCrystal.transform.GetChild(3);
            blueCrystalBeamDirection = blueCrystalRaySpawn.TransformDirection(Vector3.down);
            bcPosMod = new Vector3(player.transform.position.x - blueCrystal.transform.position.x, 0, 0);
          }
          else if (playerDirection.GetBool("isIdleLeft") || playerDirection.GetBool("isLeft"))
          {
            blueCrystalRaySpawn = blueCrystal.transform.GetChild(4);
            blueCrystalBeamDirection = blueCrystalRaySpawn.TransformDirection(Vector3.left);
            bcPosMod = new Vector3(0, player.transform.position.y - blueCrystal.transform.position.y, 0);
          }

          bcHit = Physics2D.Raycast(blueCrystalRaySpawn.position + bcPosMod, blueCrystalBeamDirection, 50.0f, ~layerMask);
          Debug.DrawRay(blueCrystalRaySpawn.position + bcPosMod, blueCrystalBeamDirection);

          if (bcHit != null)
          {
            blueCrystalBeam.SetColors(Color.blue, Color.blue);
            blueCrystalHitPoint.position = bcHit.point;
            blueCrystalBeam.SetPosition(0, bcLightSpawn.position + bcPosMod);
            blueCrystalBeam.SetPosition(1, blueCrystalHitPoint.position);
            blueCrystalBeam.enabled = true;

            if(bcHit.collider.name == redCrystal.name)
            {
              redCrystalRaySpawn = redCrystal.transform.GetChild(3);
              redCrystalBeamDirection = redCrystalRaySpawn.TransformDirection(Vector3.down);
              rcPosMod = new Vector3(player.transform.position.x - redCrystal.transform.position.x, 0, 0);
              rcHit = Physics2D.Raycast(redCrystalRaySpawn.position + rcPosMod, redCrystalBeamDirection, 50.0f, ~layerMask);
              Debug.DrawRay(redCrystalRaySpawn.position + rcPosMod, redCrystalBeamDirection);
              if(rcHit != null)
              {
                redCrystalBeam.SetColors(Color.magenta, Color.magenta);
                redCrystalHitPoint.position = rcHit.point;
                redCrystalBeam.SetPosition(0, rcLightSpawn.position + rcPosMod);
                redCrystalBeam.SetPosition(1, redCrystalHitPoint.position);
                redCrystalBeam.enabled = true;
              }
            }
            else if (bcHit.collider.name == greenCrystal.name)
            {
              greenCrystalRaySpawn = greenCrystal.transform.GetChild(1);
              greenCrystalBeamDirection = greenCrystalRaySpawn.TransformDirection(Vector3.up);
              gcPosMod = new Vector3(player.transform.position.x - greenCrystal.transform.position.x, 0, 0);
              gcHit = Physics2D.Raycast(greenCrystalRaySpawn.position + gcPosMod, greenCrystalBeamDirection, 50.0f, ~layerMask);
              Debug.DrawRay(greenCrystalRaySpawn.position + gcPosMod, greenCrystalBeamDirection);
              if (gcHit != null)
              {
                greenCrystalBeam.SetColors(Color.cyan, Color.cyan);
                greenCrystalHitPoint.position = gcHit.point;
                greenCrystalBeam.SetPosition(0, gcLightSpawn.position + gcPosMod);
                greenCrystalBeam.SetPosition(1, greenCrystalHitPoint.position);
                greenCrystalBeam.enabled = true;
              }
            }
          }
        }
        else if (pHit.name == greenCrystal.name)
        {
          if (playerDirection.GetBool("isIdleUp") || playerDirection.GetBool("isUp"))
          {
            greenCrystalRaySpawn = greenCrystal.transform.GetChild(1);
            greenCrystalBeamDirection = greenCrystalRaySpawn.TransformDirection(Vector3.up);
            gcPosMod = new Vector3(player.transform.position.x - greenCrystal.transform.position.x, 0, 0);
          }
          else if (playerDirection.GetBool("isIdleRight") || playerDirection.GetBool("isRight"))
          {
            greenCrystalRaySpawn = greenCrystal.transform.GetChild(2);
            greenCrystalBeamDirection = greenCrystalRaySpawn.TransformDirection(Vector3.right);
            gcPosMod = new Vector3(0, player.transform.position.y - greenCrystal.transform.position.y, 0);
          }
          else if (playerDirection.GetBool("isIdleDown") || playerDirection.GetBool("isDown"))
          {
            greenCrystalRaySpawn = greenCrystal.transform.GetChild(3);
            greenCrystalBeamDirection = greenCrystalRaySpawn.TransformDirection(Vector3.down);
            gcPosMod = new Vector3(player.transform.position.x - greenCrystal.transform.position.x, 0, 0);
          }
          else if (playerDirection.GetBool("isIdleLeft") || playerDirection.GetBool("isLeft"))
          {
            greenCrystalRaySpawn = greenCrystal.transform.GetChild(4);
            greenCrystalBeamDirection = greenCrystalRaySpawn.TransformDirection(Vector3.left);
            gcPosMod = new Vector3(0, player.transform.position.y - greenCrystal.transform.position.y, 0);
          }

          gcHit = Physics2D.Raycast(greenCrystalRaySpawn.position + gcPosMod, greenCrystalBeamDirection, 50.0f, ~layerMask);
          Debug.DrawRay(greenCrystalRaySpawn.position + gcPosMod, greenCrystalBeamDirection);

          if (gcHit != null)
          {
            greenCrystalBeam.SetColors(Color.green, Color.green);
            greenCrystalHitPoint.position = gcHit.point;
            greenCrystalBeam.SetPosition(0, gcLightSpawn.position + gcPosMod);
            greenCrystalBeam.SetPosition(1, greenCrystalHitPoint.position);
            greenCrystalBeam.enabled = true;
            
            if(gcHit.collider.name == blueCrystal.name)
            {
              blueCrystalRaySpawn = blueCrystal.transform.GetChild(3);
              blueCrystalBeamDirection = blueCrystalRaySpawn.TransformDirection(Vector3.down);
              bcPosMod = new Vector3(player.transform.position.x - blueCrystal.transform.position.x, 0, 0);
              bcHit = Physics2D.Raycast(blueCrystalRaySpawn.position + bcPosMod, blueCrystalBeamDirection, 50.0f, ~layerMask);
              Debug.DrawRay(blueCrystalRaySpawn.position + bcPosMod, blueCrystalBeamDirection);
              
              if(bcHit != null)
              {
                blueCrystalBeam.SetColors(Color.cyan, Color.cyan);
                blueCrystalHitPoint.position = bcHit.point;
                blueCrystalBeam.SetPosition(0, bcLightSpawn.position + bcPosMod);
                blueCrystalBeam.SetPosition(1, blueCrystalHitPoint.position);
                blueCrystalBeam.enabled = true;
                
                if(bcHit.collider.name == redCrystal.name)
                {
                  redCrystalRaySpawn = redCrystal.transform.GetChild(3);
                  redCrystalBeamDirection = redCrystalRaySpawn.TransformDirection(Vector3.down);
                  rcPosMod = new Vector3(player.transform.position.x - redCrystal.transform.position.x, 0, 0);
                  rcHit = Physics2D.Raycast(redCrystalRaySpawn.position + rcPosMod, redCrystalBeamDirection, 50.0f, ~layerMask);
                  Debug.DrawRay(redCrystalRaySpawn.position + rcPosMod, redCrystalBeamDirection);
                  if(rcHit != null)
                  {
                    redCrystalBeam.SetColors(Color.white, Color.white);
                    redCrystalHitPoint.position = rcHit.point;
                    redCrystalBeam.SetPosition(0, rcLightSpawn.position + rcPosMod);
                    redCrystalBeam.SetPosition(1, redCrystalHitPoint.position);
                    redCrystalBeam.enabled = true;
                  }
                }
              }
            }
            else if(gcHit.collider.name == redCrystal.name)
            {
              redCrystalRaySpawn = redCrystal.transform.GetChild(3);
              redCrystalBeamDirection = redCrystalRaySpawn.TransformDirection(Vector3.down);
              rcPosMod = new Vector3(player.transform.position.x - redCrystal.transform.position.x, 0, 0);
              rcHit = Physics2D.Raycast(redCrystalRaySpawn.position + rcPosMod, redCrystalBeamDirection, 50.0f, ~layerMask);
              Debug.DrawRay(redCrystalRaySpawn.position + rcPosMod, redCrystalBeamDirection);
              
              if(rcHit != null)
              {
                redCrystalBeam.SetColors(Color.yellow, Color.yellow);
                redCrystalHitPoint.position = rcHit.point;
                redCrystalBeam.SetPosition(0, rcLightSpawn.position + rcPosMod);
                redCrystalBeam.SetPosition(1, redCrystalHitPoint.position);
                redCrystalBeam.enabled = true;
              }
            }
          }
        }
      }
    }
}
