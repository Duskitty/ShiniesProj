using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3P2Manager : MonoBehaviour
{
    private GameObject player;
    private bool inSun;
    public SunlightTrigger[] sunPatches;
    private GameObject door;
    private bool doorOpening;
    private Collider2D playerHit;
    private bool button1Pressed;
    private GameObject button1;
    private bool button2Pressed;
    private GameObject button2;
    private bool iceGemAvailable;
    private GameObject iceGem;
    private bool isCreatingEnemy;
    public GameObject rockBugPrefab;
    private GameObject rockBug;
    private Transform rockBugSpawn;
    private Transform enemyPointLeft;
    private Transform enemyPointRight;
    
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("Player");
      door = GameObject.Find("CaveDoor");
      doorOpening = false;
      iceGemAvailable = false;
      iceGem = GameObject.Find("iceGem");
      button1 = GameObject.Find("exitButton0");
      button2 = GameObject.Find("exitButton1");
      rockBug = GameObject.Find("RockBug");
      rockBugSpawn = GameObject.Find("RockBugSpawn").transform;
      isCreatingEnemy = false;
      enemyPointLeft = GameObject.Find("EnemyPointLeft").transform;
      enemyPointRight = GameObject.Find("EnemyPointRight").transform;
    }

    // Update is called once per frame
    void Update()
    {
      button1Pressed = button1.GetComponent<pressButton>().getIsPressed();
      button2Pressed = button2.GetComponent<pressButton>().getIsPressed();
      player.transform.GetChild(10).GetComponent<castBeam>().clearBeams(null);
      inSun = checkInSun();

      if(rockBug == null  && !isCreatingEnemy)
      {
        StartCoroutine(createEnemy());
      }

      if (inSun)
      {
        player.transform.GetChild(10).GetComponent<castBeam>().reflect();
      }

      if(button1Pressed && button2Pressed && !doorOpening)
      {
        // Start coroutine for opening the door
        doorOpening = true;
        StartCoroutine(openDoor());
      }
    }

  private bool checkInSun()
  {
    for(int i = 0; i < sunPatches.Length; i++)
    {
      if (sunPatches[i].inSunlight)
      {
        return true;
      }
    }
    return false;
  }

  IEnumerator openDoor()
  {
    door.GetComponent<Animator>().SetBool("isOpening", true);
    yield return new WaitForSeconds(0.2f);

    Destroy(door);
    yield return null;
  }

  IEnumerator createEnemy()
  {
    isCreatingEnemy = true;
    yield return new WaitForSeconds(7f);
    rockBug = Instantiate(rockBugPrefab, rockBugSpawn.transform.position, rockBugSpawn.transform.rotation);
    rockBug.GetComponent<WaypointFinder>().waypoints[0] = enemyPointRight;
    rockBug.GetComponent<WaypointFinder>().waypoints[1] = enemyPointLeft;
    enemyPointLeft.position = new Vector3(enemyPointLeft.position.x, rockBug.transform.position.y, 0);
    enemyPointRight.position = new Vector3(enemyPointRight.position.x, rockBug.transform.position.y, 0);
    isCreatingEnemy = false;
    yield return null;
  }
}
