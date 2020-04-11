using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2P3Manager : MonoBehaviour
{
    //public bool pressed;
    private GameObject player;
    private bool inSun;
    public GameObject[] torches;
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
      playerHit = player.transform.GetChild(10).GetComponent<castBeam>().getPlayerHitCollider();
      if (playerHit != null)
      {
        Debug.Log("you hit " + playerHit.name);
      }
      /*if ((inSun && !pressed) || (inSun && pressed && reflectGem) || (!inSun && pressed && reflectGem))
      {
        player.transform.GetChild(10).GetComponent<castBeam>().reflect(null);
      }
      else if (pressed && fireGem)
      {
        player.transform.GetChild(10).GetComponent<castBeam>().castFire();
        player.transform.GetChild(10).GetComponent<LineRenderer>().enabled = false;
      }
      else
      {
        player.transform.GetChild(10).GetComponent<LineRenderer>().enabled = false;
      }*/

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
