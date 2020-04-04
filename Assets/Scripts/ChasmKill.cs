using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Pathfinding
{
  //using Pathfinding.RVO;
  using Pathfinding.Util;
  public class ChasmKill : MonoBehaviour
  {
    private Transform player;
    public Transform respawn;

    void Start()
    {
      player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
      bool buttonPressed = GameObject.Find("Button").GetComponent<ButtonPressed>().pressed;
      bool playerSafe = GameObject.Find("Player").GetComponent<PlayerMovement>().bridgeSafe;
      if (buttonPressed == false && playerSafe == false)
      {
        player.position = respawn.position;
      }
    }
  }
}
