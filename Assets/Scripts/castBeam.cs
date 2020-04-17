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
    private GameObject fireBall;
    private bool firePlaying;
    private Collider2D playerHitCollider;
    public GameObject iceSpawn;
    private RaycastHit2D[] iceHits;
    private Transform iceHitPoint;
    private Transform iceRaySpawn;
    private Vector2 iceDirection;
    private Vector3 iceEndMod;

    private LineRenderer[] hittableObjBeams;
    public SunlightTrigger[] sunPatches;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerLightSpawn = this.transform;
        playerFireSpawn = player.transform.GetChild(11);
        playerBeam = this.GetComponent<LineRenderer>();
        playerFireBeam = playerFireSpawn.GetComponent<LineRenderer>();
        playerBeam.enabled = false;
        playerFireBeam.enabled = false;
        playerDirection = player.GetComponent<Animator>();
        layerMask = LayerMask.GetMask("SunPatch");
        fireHits = new RaycastHit2D[10];
        firePlaying = false;
        
    }

    public Collider2D reflect()
    {
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
        else if (playerDirection.GetBool("isIdleLeft"))
        {
            playerHitPoint = player.transform.GetChild(7);
            playerRaySpawn = player.transform.GetChild(3);
            beamDirection = playerRaySpawn.TransformDirection(Vector3.left);
        }
        else
        {
          return null;
        }

        playerHit = Physics2D.Raycast(playerRaySpawn.position, beamDirection, 50.0f, ~layerMask);
        //Debug.DrawRay(playerRaySpawn.position, beamDirection);


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
            fireBall = GameObject.Find("FireUp");
            fireEndMod = new Vector3(0, .7f, 0);
        }
        else if (playerDirection.GetBool("isIdleRight"))
        {
            playerHitPoint = player.transform.GetChild(6);
            playerRaySpawn = player.transform.GetChild(2);
            fireDirection = new Vector2(1, 0);
            fireBall = GameObject.Find("FireRight");
            fireEndMod = new Vector3(.7f, 0, 0);
        }
        else if (playerDirection.GetBool("isIdleDown"))
        {
            playerHitPoint = player.transform.GetChild(8);
            playerRaySpawn = player.transform.GetChild(4);
            fireDirection = new Vector2(0, -1);
            fireBall = GameObject.Find("FireDown");
            fireEndMod = new Vector3(0, -.7f, 0);
        }
        else if (playerDirection.GetBool("isIdleLeft"))
        {
            playerHitPoint = player.transform.GetChild(7);
            playerRaySpawn = player.transform.GetChild(3);
            fireDirection = new Vector2(-1, 0);
            fireBall = GameObject.Find("FireLeft");
            fireEndMod = new Vector3(-.7f, 0, 0);
        }
        else
        {
            return;
        }
        if (!firePlaying)
        {
            fireHits = Physics2D.BoxCastAll(playerRaySpawn.position + fireEndMod, new Vector2(1, 0.25f), 0f, fireDirection, 1f, ~layerMask);
            StartCoroutine(fireBurst());
        }
    }

    public void castIce()
    {
      GameObject ice = Instantiate(iceSpawn, player.transform.position, player.transform.rotation);
      iceHitPoint = ice.transform.GetChild(4);

      if (playerDirection.GetBool("isIdleUp"))
      {
        iceRaySpawn = player.transform.GetChild(0);
        iceDirection = new Vector2(0, 1);
        iceEndMod = new Vector3(0, 3, 0);
      }
      else if (playerDirection.GetBool("isIdleRight"))
      {
        iceRaySpawn = player.transform.GetChild(3);
        iceDirection = new Vector2(1, 0);
        iceEndMod = new Vector3(3, 0, 0);
      }
      else if (playerDirection.GetBool("isIdleDown"))
      {
        iceRaySpawn = player.transform.GetChild(2);
        iceDirection = new Vector2(0, -1);
        iceEndMod = new Vector3(0, -3, 0);
      }
      else if (playerDirection.GetBool("isIdleLeft"))
      {
        iceRaySpawn = player.transform.GetChild(1);
        iceDirection = new Vector2(-1, 0);
        iceEndMod = new Vector3(-3, 0, 0);
      }
      else
      {
        return;
      }

      iceHits = Physics2D.BoxCastAll(iceRaySpawn.position, new Vector2(.5f, 1.5f), 0f, iceDirection, 1f, ~layerMask);
      ice.GetComponent<LineRenderer>().SetPosition(0, ice.transform.position);
      ice.GetComponent<LineRenderer>().SetPosition(1, ice.transform.position + iceEndMod);
      ice.GetComponent<LineRenderer>().enabled = true;
      //StartCoroutine(meltIce(ice));
    }

    public void disableLight()
    {
        playerBeam.enabled = false;
    }

    IEnumerator fireBurst()
    {
        if (fireBall != null)
        {
            firePlaying = true;
            fireBall.GetComponent<SpriteRenderer>().enabled = true;
            fireBall.GetComponent<Animator>().SetBool("isActive", true);
            //yield return new WaitForSeconds(0.45f);
            for (int i = 0; i < fireHits.Length; i++)
            {
                if (fireHits[i] != null)//re look at this statment because it saying it going to always return true 
                {
                    hitObj = GameObject.Find(fireHits[i].collider.name);
                    if (hitObj != null && hitObj.tag == "Cactus" && !hitObj.GetComponent<Animator>().GetBool("isBurned"))
                    {
                        //StopCoroutine(burnCactus());
                        StartCoroutine(burnCactus(hitObj));
                    }
                    else if (hitObj != null && hitObj.tag == "Torch")
                    {
                        Debug.Log("hit torch");
                        hitObj.GetComponent<Animator>().SetBool("isLit", true);
                        hitObj.transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
            }
        }
        yield return new WaitForSeconds(.5f);
        fireBall.GetComponent<SpriteRenderer>().enabled = false;
        fireBall.GetComponent<Animator>().SetBool("isActive", false);
        yield return new WaitForSeconds(2);
        firePlaying = false;
        yield return null;
    }

    IEnumerator burnCactus(GameObject hitObj)
    {
      //Debug.Log(hitObj.name + " " + hitObj.GetComponent<Animator>().GetBool("isBurned"));

      hitObj.GetComponent<Animator>().SetBool("isBurned", true);
      yield return new WaitForSeconds(0.4f);
      hitObj.GetComponent<Animator>().SetBool("isBurned", false);
      Destroy(hitObj);
      yield return null;
    }

    IEnumerator meltIce(GameObject ice)
    {
      yield return new WaitForSeconds(3);
      Destroy(ice);
      yield return null;
    }

  public void ButtonPress()
    {
        if ((checkInSunlight() && GemPick.fireGem) ||(!checkInSunlight() && GemPick.fireGem && GameControlScript.charges >= 1))
        {
            castFire();
            GetComponent<LineRenderer>().enabled = false;
            if (!checkInSunlight())
            {
              GameControlScript.charges -= 1;
            }
        }
        else if ((checkInSunlight() && GemPick.reflectGem) || (!checkInSunlight() && GemPick.reflectGem && GameControlScript.charges >= 1))
        {
            Debug.Log("here");
            playerHitCollider = reflect();
            if (!checkInSunlight())
            {
              GameControlScript.charges -= 1;
            }
        }
        else if ((checkInSunlight() && GemPick.iceGem) || (!checkInSunlight() && GemPick.iceGem && GameControlScript.charges >= 1))
        {
          //cast ice
          GetComponent<LineRenderer>().enabled = false;
          if (!checkInSunlight())
          {
            GameControlScript.charges -= 1;
          }
        }
        else
        {
          castIce();
        }
    }

    public bool checkInSunlight()
    {
      for (int i = 0; i < sunPatches.Length; i++)
      {
        if (sunPatches[i].inSunlight)
        {
          return true;
        }
      }
      return false;
    }

    public Collider2D getPlayerHitCollider()
    {
      return playerHitCollider;
    }

    /*public void setHittableObjBeams(LineRenderer[] hittableObjs)
    {
      hittableObjBeams = new LineRenderer[hittableObjs.Length];
      for (int i = 0; i < hittableObjs.Length; i++)
      {
        hittableObjBeams[i] = hittableObjs[i];
      }
    }*/

    public void clearBeams(LineRenderer[] hittableObjBeams)
    {
      if (playerDirection.GetBool("isMoving"))
      {
        if (hittableObjBeams != null)
        {
          for (int i = 0; i < hittableObjBeams.Length; i++)
          {
            hittableObjBeams[i].enabled = false;
            //Debug.Log(hittableObjBeams[i].enabled);
          }
        }
        playerBeam.enabled = false;
      }
    }
}
