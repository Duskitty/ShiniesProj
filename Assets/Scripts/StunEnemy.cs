using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEnemy: MonoBehaviour
{
  public int stunTime;
  private bool isStunned;

  public void stun(GameObject enemy)
  {
    //Debug.Log("Enemy stunned");
    enemy.GetComponent<WaypointFinder>().enabled = false;
    isStunned = true;
    StartCoroutine(holdStun(enemy));
  }

  public bool getIsStunned()
  {
    return isStunned;
  }

  IEnumerator holdStun(GameObject enemy)
  {
    yield return new WaitForSeconds(stunTime);
    enemy.GetComponent<WaypointFinder>().enabled = true;
    isStunned = false;
  }
}
