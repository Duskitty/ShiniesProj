using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Manager : MonoBehaviour
{
    private GameObject frozenRock;
    private GameObject stairs;
    private RaycastHit2D hit;
    private SpriteRenderer orb;

    public Sprite litOrb;

    void Start()
    {
      frozenRock = GameObject.Find("Puzzle1Rock00");
      stairs = GameObject.Find("Stairs");
      hit = Physics2D.Raycast(frozenRock.transform.GetChild(2).position, frozenRock.transform.GetChild(2).TransformDirection(Vector3.right));
      frozenRock.transform.GetChild(1).position = hit.point;
      frozenRock.transform.GetChild(0).GetComponent<LineRenderer>().SetPosition(0, frozenRock.transform.GetChild(0).position);
      frozenRock.transform.GetChild(0).GetComponent<LineRenderer>().SetPosition(1, frozenRock.transform.GetChild(1).position);
      orb = GameObject.Find("Puzzle1Button").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      hit = Physics2D.Raycast(frozenRock.transform.GetChild(2).position, frozenRock.transform.GetChild(2).TransformDirection(Vector3.right));
      frozenRock.transform.GetChild(1).position = hit.point;
      frozenRock.transform.GetChild(0).GetComponent<LineRenderer>().SetPosition(0, frozenRock.transform.GetChild(0).position);
      frozenRock.transform.GetChild(0).GetComponent<LineRenderer>().SetPosition(1, frozenRock.transform.GetChild(1).position);

      if(hit.collider.name == "Puzzle1Button")
      {
        stairs.GetComponent<BoxCollider2D>().enabled = false;
        stairs.GetComponent<SpriteRenderer>().enabled = true;
        orb.sprite = litOrb;
      }
    }
}
