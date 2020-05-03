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
    public GameObject rockBugPrefab;
    private GameObject rockBug;
    private bool creatingBug;
    private Transform rockBugPos;
    private Transform enemyLeftPoint;
    private Transform enemyRightPoint;
    
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
      creatingBug = false;
      rockBugPos = GameObject.Find("RockBugPos").transform;
      enemyLeftPoint = GameObject.Find("EnemyPointLeft").transform;
      enemyRightPoint = GameObject.Find("EnemyPointRight").transform;
    }

    // Update is called once per frame
    void Update()
    {
      if(rockBug == null && !creatingBug)
      {
        StartCoroutine(createRockBug());
      }
      button1Pressed = button1.GetComponent<pressButton>().getIsPressed();
      button2Pressed = button2.GetComponent<pressButton>().getIsPressed();
      player.transform.GetChild(10).GetComponent<castBeam>().clearBeams(null);
      inSun = checkInSun();

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

  IEnumerator createRockBug()
  {
    creatingBug = true;
    yield return new WaitForSeconds(6f);
    rockBug = Instantiate(rockBugPrefab, rockBugPos.position, rockBugPos.rotation);
    enemyLeftPoint.position = new Vector3(enemyLeftPoint.position.x, rockBug.transform.position.y, 0);
    enemyRightPoint.position = new Vector3(enemyRightPoint.position.x, rockBug.transform.position.y, 0);
    rockBug.GetComponent<WaypointFinder>().waypoints[0] = enemyRightPoint;
    rockBug.GetComponent<WaypointFinder>().waypoints[1] = enemyLeftPoint;
    creatingBug = false;
    yield return null;
  }
}
