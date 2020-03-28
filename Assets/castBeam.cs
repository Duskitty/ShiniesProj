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
    private Transform playerFireSpawn;
    private LineRenderer playerFireBeam;
    private Vector3 beamDirection;
    private int beamDirectionNum;
    private RaycastHit2D playerHit;
    private LayerMask layerMask;
    private RaycastHit2D[] fireHits;
    private Vector2 fireDirection;
    private Vector3 fireEndMod;
  private GameObject hitObj;

    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("Player");
      playerLightSpawn = this.transform;
      //playerFireSpawn = player.transform.GetChild(11);
      playerBeam = this.GetComponent<LineRenderer>();
      playerFireBeam = playerFireSpawn.GetComponent<LineRenderer>();
      playerBeam.enabled = false;
      playerFireBeam.enabled = false;
      playerDirection = player.GetComponent<Animator>();
      layerMask = LayerMask.GetMask("SunPatch");
      fireHits = new RaycastHit2D[10];
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

  public void castFire()
  {
    if (playerDirection.GetBool("isIdleUp"))
    {
      playerHitPoint = player.transform.GetChild(5);
      playerRaySpawn = player.transform.GetChild(1);
      fireDirection = new Vector2(0, 1);
      fireEndMod = new Vector3(0, 3, 0);
    }
    else if (playerDirection.GetBool("isIdleRight"))
    {
      playerHitPoint = player.transform.GetChild(6);
      playerRaySpawn = player.transform.GetChild(2);
      fireDirection = new Vector2(1, 0);
      fireEndMod = new Vector3(3, 0, 0);
    }
    else if (playerDirection.GetBool("isIdleDown"))
    {
      playerHitPoint = player.transform.GetChild(8);
      playerRaySpawn = player.transform.GetChild(4);
      fireDirection = new Vector2(0, -1);
      fireEndMod = new Vector3(0, -3, 0);
    }
    else
    {
      playerHitPoint = player.transform.GetChild(7);
      playerRaySpawn = player.transform.GetChild(3);
      fireDirection = new Vector2(-1, 0);
      fireEndMod = new Vector3(-3, 0, 0);
    }

    fireHits = Physics2D.BoxCastAll(playerRaySpawn.position, new Vector2(1, 1.5f), 0f, fireDirection, 1f, ~layerMask);
    playerFireBeam.SetPosition(0, playerFireSpawn.position);
    playerFireBeam.SetPosition(1, playerFireSpawn.position + fireEndMod);
    playerFireBeam.enabled = true;

    for (int i = 0; i < fireHits.Length; i++)
    {
      if(fireHits[i] != null)
      {
        hitObj = GameObject.Find(fireHits[i].collider.name);
        if (hitObj.tag == "Cactus")
        {
          Destroy(hitObj);
        }
      }
    }
    
  }

  public void disableFire()
  {
    playerFireBeam.enabled = false;
  }

  public void disableLight()
  {
    playerBeam.enabled = false;
  }
}
