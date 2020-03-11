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
    isStunned = true;
    enemy.GetComponent<WaypointFinder>().enabled = false;
    StartCoroutine(holdStun(enemy));
  }

  IEnumerator holdStun(GameObject enemy)
  {
    yield return new WaitForSeconds(stunTime);
    enemy.GetComponent<WaypointFinder>().enabled = true;
    isStunned = false;
  }

  public bool checkIsStunned()
  {
    return isStunned;
  }
}
