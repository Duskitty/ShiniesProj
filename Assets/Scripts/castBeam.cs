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
    public GameObject iceBlock;
    public GameObject enemyIceBlock;
    private RaycastHit2D[] iceHits;
    private Transform iceHitPoint;
    private Transform iceRaySpawn;
    private Vector2 iceDirection;
    private Vector3 iceEndMod;
    private GameObject iceBall;
    private Color iceColor;
    //private GameObject[] frozenEnemies;
    //private GameObject[] iceBlocks;
    private LineRenderer[] hittableObjBeams;
    public SunlightTrigger[] sunPatches;
    private bool fireHitSomething;
    private bool iceHitSomething;
  private Transform enemyLeftPoint;
  private Transform enemyRightPoint;

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
        //frozenEnemies = new GameObject[10];
        //iceBlocks = new GameObject[10];  
        fireHitSomething = false;
        iceHitSomething = false;
    }

    public Collider2D reflect()
    {
        fireHitSomething = false;
        iceHitSomething = false;
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

    public Collider2D castFire()
    {
        disableLight();
        iceHitSomething = false;
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
            fireHitSomething = false;
            return null;
        }
        if (!firePlaying)
        {
            fireHits = Physics2D.BoxCastAll(playerRaySpawn.position, new Vector2(1, 0.25f), 0f, fireDirection, 1f, ~layerMask);
            StartCoroutine(fireBurst());
          for (int i = 0; i < fireHits.Length; i++)
          {
            if (fireHits[i].collider.tag == "Boss")
            {
              fireHitSomething = true;
              return fireHits[i].collider;
            }   
          }
   
        }
      fireHitSomething = false;
      return null;
    }

    public void castIce()
    {
      disableLight();
      GameObject ice = Instantiate(iceSpawn, player.transform.position, player.transform.rotation);
      iceHitPoint = ice.transform.GetChild(4);
      fireHitSomething = false;

      if (playerDirection.GetBool("isIdleUp"))
      {
        iceRaySpawn = player.transform.GetChild(0);
        iceDirection = new Vector2(0, 1);
        iceEndMod = new Vector3(0, 4, 0);
        iceBall = GameObject.Find("iceUp");
        StartCoroutine(animateIcePath(ice.transform.GetChild(0), ice));
      }
      else if (playerDirection.GetBool("isIdleRight"))
      {
        iceRaySpawn = player.transform.GetChild(3);
        iceDirection = new Vector2(1, 0);
        iceEndMod = new Vector3(4, 0, 0);
        iceBall = GameObject.Find("iceRight");
        StartCoroutine(animateIcePath(ice.transform.GetChild(3), ice));
      }
      else if (playerDirection.GetBool("isIdleDown"))
      {
        iceRaySpawn = player.transform.GetChild(2);
        iceDirection = new Vector2(0, -1);
        iceEndMod = new Vector3(0, -4, 0);
        iceBall = GameObject.Find("iceDown");
        StartCoroutine(animateIcePath(ice.transform.GetChild(2), ice));
      }
      else if (playerDirection.GetBool("isIdleLeft"))
      {
        iceRaySpawn = player.transform.GetChild(1);
        iceDirection = new Vector2(-1, 0);
        iceEndMod = new Vector3(-4, 0, 0);
        iceBall = GameObject.Find("iceLeft");
        StartCoroutine(animateIcePath(ice.transform.GetChild(1), ice));
      }
      else
      {
        return;
      }

      iceHits = Physics2D.BoxCastAll(player.transform.position, new Vector2(1.3f, 1.5f), 0f, iceDirection, 1f);
      //ice.GetComponent<LineRenderer>().SetPosition(0, ice.transform.position);
      //ice.GetComponent<LineRenderer>().SetPosition(1, ice.transform.position + iceEndMod);
      //ice.GetComponent<LineRenderer>().enabled = true;
      StartCoroutine(iceBurst());

      if(iceHits != null)
      {
        for(int i = 0; i < iceHits.Length; i++)
        {
          hitObj = GameObject.Find(iceHits[i].collider.name);
          if (hitObj.tag == "WaterCollider")
          {
            hitObj.GetComponent<BoxCollider2D>().enabled = false;
          }
          else if(hitObj.tag == "enemy")
          {
            StartCoroutine(meltEnemy(hitObj));
          }
          // BEN BOSS 3 HIT BY ICE GOES HERE
          //
          //
          // EEEEEEEEEEEEEE
          else if (hitObj.tag == "Boss3")
          {
            iceHitSomething = true;
                    if (Boss.fireAttack == true)
                    {
                        GameObject.FindWithTag("Boss3").GetComponent<Boss>().TakeDamage();
                    }

                }
            }
      }
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
                    else if (hitObj != null && hitObj.tag == "IceBlock")
                    {
                        StartCoroutine(refreezeIce(hitObj));
                    }
                    else if (hitObj != null && hitObj.tag == "EnemyIceBlock")
                    {
                      StopCoroutine(meltEnemy(hitObj));
                      StartCoroutine(meltEnemyWithFire(hitObj));
                    }
                    else if(hitObj != null && hitObj.tag == "enemy")
                    {
                      Destroy(hitObj);
                    }
                    //BRENDAN ADD CODE FOR BOSS 2 FIRE HERE
                    else if (hitObj != null && hitObj.tag == "Boss2")
                    {
                        B2Script.health--;
                        Debug.Log(B2Script.health);
                        GameObject.FindGameObjectWithTag("HealthBar").transform.localScale = new Vector3((B2Script.health / 30.0f), 1f, 1f);
                        if (B2Script.health == 0)
                        {
                            GameObject.Find("Controller").SetActive(false);
                            SpawnChargeGem.deadBoss = true;
                        }
                        else if (B2Script.health <= 10)
                        {
                            B2Script.attackHold = 1.5;
                            B2Script.spikeHold = 1;
                        }
                        else if (B2Script.health <= 20)
                        {
                            B2Script.attackHold = 3;
                            B2Script.spikeHold = 2;
                        }
                    }
                    //BEN ADD CODE FOR BOSS 3 FIRE HERE
                    //
                    //
                    //
                    else if (hitObj != null && hitObj.tag == "Boss3")
                    {
                        if (Boss.iceAttack == true) {
                            GameObject.FindWithTag("Boss3").GetComponent<Boss>().TakeDamage();
                        }
                    }
                }
            }
        }
        yield return new WaitForSeconds(.5f);
        fireBall.GetComponent<SpriteRenderer>().enabled = false;
        fireBall.GetComponent<Animator>().SetBool("isActive", false);
        yield return new WaitForSeconds(.6f);
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
            playerHitCollider = reflect();
            if (!checkInSunlight())
            {
              GameControlScript.charges -= 1;
            }
        }
        else if ((checkInSunlight() && GemPick.iceGem) || (!checkInSunlight() && GemPick.iceGem && GameControlScript.charges >= 1))
        {
          //cast ice
          castIce();
          GetComponent<LineRenderer>().enabled = false;
          if (!checkInSunlight())
          {
            GameControlScript.charges -= 1;
          }
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

  public void setPlayerHitCollider(Collider2D newCollider)
  {
    playerHitCollider = newCollider;
  }

  IEnumerator iceBurst()
  {
    if (iceBall != null)
    {
      //firePlaying = true;
      iceBall.GetComponent<SpriteRenderer>().enabled = true;
      iceBall.GetComponent<Animator>().SetBool("isActive", true);
      //yield return new WaitForSeconds(0.45f); 
    }
    yield return new WaitForSeconds(.5f);
    iceBall.GetComponent<SpriteRenderer>().enabled = false;
    iceBall.GetComponent<Animator>().SetBool("isActive", false);
    yield return new WaitForSeconds(2);
    //firePlaying = false;
    yield return null;
  }

  IEnumerator animateIcePath(Transform iceRaySpawn, GameObject ice)
  {
    //iceRaySpawn.GetComponent<BoxCollider2D>().enabled = true;
    iceColor = iceRaySpawn.GetChild(0).GetComponent<SpriteRenderer>().color;
    for(int i = 0; i <= 10; i += 2)
    {
      iceRaySpawn.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = true;
      iceRaySpawn.transform.GetChild(i+1).gameObject.GetComponent<SpriteRenderer>().enabled = true;
      yield return new WaitForSeconds(.1f);
    }
    yield return new WaitForSeconds(10);
    //iceRaySpawn.GetComponent<BoxCollider2D>().enabled = false;
    if (ice.tag != "EnemyIceBlock")
    {
      for (float f = 1f; f >= -0.05f; f -= 0.05f)
      {
        //Debug.Log("here");
        Color c = iceRaySpawn.GetChild(0).GetComponent<SpriteRenderer>().color;
        c.a = f;
        for (int i = 0; i <= 10; i += 2)
        {
          iceRaySpawn.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = c;
          iceRaySpawn.transform.GetChild(i + 1).gameObject.GetComponent<SpriteRenderer>().color = c;
        }
        yield return new WaitForSeconds(0.05f);
      }

      Destroy(ice);
    }
    if (iceHits != null)
    {
      for (int i = 0; i < iceHits.Length; i++)
      {
        if (iceHits[i].collider != null)
        {
          hitObj = GameObject.Find(iceHits[i].collider.name);
          if (hitObj != null)
          {
            if (hitObj.tag == "WaterCollider")
            {
              hitObj.GetComponent<BoxCollider2D>().enabled = true;
            }
            else
            {
              continue;
            }
          }
        }
      }
    }
    yield return null;
  }

  IEnumerator meltEnemy(GameObject enemy)
  {
    enemyLeftPoint = GameObject.Find("EnemyPointLeft").transform;
    enemyRightPoint = GameObject.Find("EnemyPointRight").transform;
    yield return new WaitForSeconds(0.1f);
    GameObject block = Instantiate(enemyIceBlock, enemy.transform.position, enemy.transform.rotation);
    block.GetComponent<containsEnemy>().enemy = enemy;
    enemy.SetActive(false);

    yield return new WaitForSeconds(74f);
    enemy.SetActive(true);
    enemy.transform.position = block.transform.position;
    enemyLeftPoint.position = new Vector3(enemyLeftPoint.position.x, enemy.transform.position.y, 0);
    enemyRightPoint.position = new Vector3(enemyRightPoint.position.x, enemy.transform.position.y, 0);
    yield return new WaitForSeconds(1f);
    Destroy(block);
    yield return null;
  }

  IEnumerator meltEnemyWithFire(GameObject iceBlock)
  {
    iceBlock.GetComponent<Animator>().SetBool("hitWithFire", true);
    yield return new WaitForSeconds(.45f);
    iceBlock.GetComponent<containsEnemy>().enemy.transform.position = iceBlock.transform.position;
    iceBlock.GetComponent<containsEnemy>().enemy.SetActive(true);
    enemyLeftPoint.position = new Vector3(enemyLeftPoint.position.x, iceBlock.GetComponent<containsEnemy>().enemy.transform.position.y, 0);
    enemyRightPoint.position = new Vector3(enemyRightPoint.position.x, iceBlock.GetComponent<containsEnemy>().enemy.transform.position.y, 0);
    Destroy(iceBlock);
    yield return null;
  }

  IEnumerator refreezeIce(GameObject iceBlock)
  {
    iceBlock.GetComponent<Animator>().SetBool("isMelting", true);
    yield return new WaitForSeconds(0.2f);
    iceBlock.GetComponent<BoxCollider2D>().enabled = false;
    yield return new WaitForSeconds(8f);
    iceBlock.GetComponent<Animator>().SetBool("isMelting", false);
    iceBlock.GetComponent<BoxCollider2D>().enabled = true;

    yield return null;
  }

  public void clearBeams(LineRenderer[] hittableObjBeams)
    {
      if (playerDirection.GetBool("isMoving"))
      {
        if (hittableObjBeams != null)
        {
          for (int i = 0; i < hittableObjBeams.Length; i++)
          {
            hittableObjBeams[i].enabled = false;
            //Debug.Log(hittableObjBeams[i].name + " " + hittableObjBeams[i].enabled);
          }
        }
        playerBeam.enabled = false;
      }
    }
}
