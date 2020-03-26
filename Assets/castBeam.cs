using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castBeam : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("Player");
      playerLightSpawn = this.transform;
      playerBeam = this.GetComponent<LineRenderer>();
      playerBeam.enabled = false;
      playerDirection = player.GetComponent<Animator>();
      layerMask = LayerMask.GetMask("SunPatch");
    }

  public Collider2D reflect(LineRenderer[] hittableObjBeams)
  { 
    if (playerDirection.GetBool("isMoving"))
    {
      //Debug.Log("is moving");
      for (int i = 0; i < hittableObjBeams.Length; i++)
      {
        //Debug.Log("in loop");
        hittableObjBeams[i].enabled = false;
        //Debug.Log(i + " " + hittableObjBeams[i].enabled);
      }
      playerBeam.enabled = false;
      return null;
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
    }



    return playerHit.collider;
  }
}
