using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevelTrigger : MonoBehaviour
{
   
  public void OnTriggerEnter2D(Collider2D thing)
  {
        Debug.Log("entered next level trigger");
        SceneManager.LoadScene("World_1_Boss", LoadSceneMode.Single);
        
  }
}
