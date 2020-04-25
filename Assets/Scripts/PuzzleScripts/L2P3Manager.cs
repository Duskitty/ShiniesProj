using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2P3Manager : MonoBehaviour
{
    //public bool pressed;
    private GameObject player;
    private bool inSun;
    public GameObject[] torches;
    public SunlightTrigger[] sunPatches;
    private GameObject door;
    private bool doorOpening;
    private Collider2D playerHit;

    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("Player");
      door = GameObject.Find("RuinsDoor");
      doorOpening = false;
    }

    // Update is called once per frame
    void Update()
    {
      player.transform.GetChild(10).GetComponent<castBeam>().clearBeams(null);
      inSun = checkInSun();

      if (inSun)
      {      
        player.transform.GetChild(10).GetComponent<castBeam>().reflect();
      }

      if (checkTorches() && door != null && !doorOpening)
      {
        StartCoroutine(openDoor());
      }
    }

  private bool checkTorches()
  {
    for(int i = 0; i < torches.Length; i++)
    {
      if (!torches[i].GetComponent<Animator>().GetBool("isLit"))
      {
        return false;
      }
    }
    return true;
  }

  private bool checkInSun()
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

  IEnumerator openDoor()
  {
    doorOpening = true;
    door.GetComponent<Animator>().SetBool("isOpening", true);
    yield return new WaitForSeconds(0.25f);
    door.GetComponent<Animator>().SetBool("isOpening", false);
    door.GetComponent<Animator>().SetBool("isOpen", true);
    door.GetComponent<BoxCollider2D>().enabled = false;

    yield return null;
  }
}
