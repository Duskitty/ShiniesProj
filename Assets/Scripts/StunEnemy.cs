using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Pathfinding
{
  //using Pathfinding.RVO;
  using Pathfinding.Util;

  public class StunEnemy : MonoBehaviour
  {
    public int stunTime;
    private bool isStunned;

    public void stun(GameObject enemy)
    {
      //Debug.Log("Enemy stunned");
      isStunned = true;
      if (enemy.GetComponent<WaypointFinder>() != null)
      {
        enemy.GetComponent<WaypointFinder>().enabled = false;
        StartCoroutine(holdStunWayFinder(enemy));
      }
      else if (enemy.GetComponent<AIPath>() != null)
      {
        enemy.GetComponent<AIPath>().enabled = false;
        //StartCoroutine(holdStunAIPath(enemy));
      }
    }

    IEnumerator holdStunWayFinder(GameObject enemy)
    {
      yield return new WaitForSeconds(stunTime);
      enemy.GetComponent<WaypointFinder>().enabled = true;
      isStunned = false;
    }

    /*IEnumerator holdStunAIPath(GameObject enemy)
    {
      yield return new WaitForSeconds(stunTime);
      enemy.GetComponent<Seeker>().enabled = true;
      isStunned = false;
    }
    */
    public bool checkIsStunned()
    {
      return isStunned;
    }
  }
}
