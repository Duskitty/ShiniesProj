using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevelTrigger : MonoBehaviour
{
    Scene currentScence;
  public void OnTriggerEnter2D(Collider2D thing)
  {
        if (currentScence.name == "World_1")
        {
            Debug.Log("entered next level trigger");
            SceneManager.LoadScene("World_1_Boss", LoadSceneMode.Single);
        }
       else if (currentScence.name == "World_1_Boss")
        {
           // Debug.Log("entered next level trigger");
            SceneManager.LoadScene("World 2 P1", LoadSceneMode.Single);
        }
        else if (currentScence.name == "World 2 P1")
        {
            // Debug.Log("entered next level trigger");
            SceneManager.LoadScene("World 2 P2", LoadSceneMode.Single);
        }
        else if (currentScence.name == "World 2 P2")
        {
            // Debug.Log("entered next level trigger");
            SceneManager.LoadScene("YouWin", LoadSceneMode.Single);
        }


    }

    private void Update()
    {
         currentScence = SceneManager.GetActiveScene();
        //Debug.Log(currentScence.name);
      

    }
}
