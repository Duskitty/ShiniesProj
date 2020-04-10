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

    private LayerMask layerMask;
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
    }

    // Update is called once per frame
    void Update()
    {
      if (GameObject.Find("SunPatch00").GetComponent<SunlightTrigger>().inSunlight)
      {
        pHit = player.transform.GetChild(10).GetComponent<castBeam>().reflect(null);
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
            rcPosMod = new Vector3(0, player.transform.position.y, 0);
          }
          else if (playerDirection.GetBool("isIdleDown") || playerDirection.GetBool("isDown"))
          {
            redCrystalRaySpawn = redCrystal.transform.GetChild(3);
            redCrystalBeamDirection = redCrystalRaySpawn.TransformDirection(Vector3.down);
            rcPosMod = new Vector3(player.transform.position.x, 0, 0);
          }
          else if (playerDirection.GetBool("isIdleLeft") || playerDirection.GetBool("isLeft"))
          {
            redCrystalRaySpawn = redCrystal.transform.GetChild(4);
            redCrystalBeamDirection = redCrystalRaySpawn.TransformDirection(Vector3.left);
            rcPosMod = new Vector3(0, player.transform.position.y, 0);
          }

          rcHit = Physics2D.Raycast(redCrystalRaySpawn.position + rcPosMod, redCrystalBeamDirection, 50.0f, ~layerMask);
          Debug.DrawRay(redCrystalRaySpawn.position + rcPosMod, redCrystalBeamDirection);
          
          if (rcHit != null)
          {
            redCrystalHitPoint.position = rcHit.point;
            redCrystalBeam.SetPosition(0, rcLightSpawn.position + rcPosMod);
            redCrystalBeam.SetPosition(1, redCrystalHitPoint.position);
            redCrystalBeam.enabled = true;
          }
        }
      }
    }
}
