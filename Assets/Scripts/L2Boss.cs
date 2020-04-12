using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2Boss : MonoBehaviour
{
  public SunlightTrigger[] sunPatches;

  // Player Variables
  private GameObject player;
  //private Animator playerDirection;
  private Collider2D hitCollider;

  // Object Variables
  //public GameObject[] reflectObjs;
  //private LineRenderer[] hittableObjBeams;


  // Start is called before the first frame update
  void Start()
  {
    player = GameObject.Find("Player");
  }

  // Update is called once per frame
  void Update()
  {
    // if in sunlight && reflect && button
    hitCollider = player.transform.GetChild(10).GetComponent<castBeam>().reflect();

    // else if fire 
    player.transform.GetChild(10).GetComponent<castBeam>().castFire();

    //if player hit boss
    //do something here

  }
}
