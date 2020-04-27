using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueScript : MonoBehaviour
{
    public void Continue()
    {
        /*
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        string sceneName = PlayerPrefs.GetString("lastLoadedScene");
        SceneManager.LoadScene(sceneName);//back to previous scene1?
        */
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
        
    
}
