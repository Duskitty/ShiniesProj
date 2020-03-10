using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MushroomMove : MonoBehaviour
{
  private float horizontal = 0f;
  private float vertical = 0f;
  public Animator animat;
  public float Delay;
  public bool isShieldBahsing = false;
  // animations for mushroom man
  public string scenetoload;
  void Update()
  {
    horizontal = Input.GetAxis("Horizontal");
    vertical = Input.GetAxis("Vertical");

    if (horizontal > 0)
    {
      animat.SetBool("Right", true);
      animat.SetBool("Moving", true);
      animat.SetBool("Left", false);
      animat.SetBool("Up", false);
      animat.SetBool("Down", false);
    }
    if (horizontal < 0)
    {
      animat.SetBool("Right", false);
      animat.SetBool("Moving", true);
      animat.SetBool("Left", true);
      animat.SetBool("Up", false);
      animat.SetBool("Down", false);
    }
    if (vertical > 0)
    {
      animat.SetBool("Right", false);
      animat.SetBool("Moving", true);
      animat.SetBool("Left", false);
      animat.SetBool("Up", true);
      animat.SetBool("Down", false);
    }
    if (vertical < 0)
    {
      animat.SetBool("Right", false);
      animat.SetBool("Moving", true);
      animat.SetBool("Left", false);
      animat.SetBool("Up", false);
      animat.SetBool("Down", true);
    }


  }
  private void OnTriggerEnter2D(Collider2D col)
  {
    animat.SetBool("Explode", true);
    if (isShieldBahsing)
    {
      //no damage taken
    }
    else
    {
      // no shield bash = 1 less heart
      GameControlScript.health -= 1;
            print(col.name);
      StartCoroutine(col.GetComponent<KnockBack>().KnockCo());


    }
    GetComponentInParent<Pathfinding.AIPath>().canMove = false;
    StartCoroutine(Die());

  }
  public IEnumerator Die()
  {
    yield return new WaitForSeconds(Delay);
    Destroy(gameObject);

  }
  public void SheildBash()
  {
    animat.SetBool("Explode", true);
    Debug.Log("about to sheild bash");

    StartCoroutine(Die());
   // ChangeScene();
  }
  void ChangeScene()
  {
    SceneManager.LoadScene(scenetoload);

  }
}