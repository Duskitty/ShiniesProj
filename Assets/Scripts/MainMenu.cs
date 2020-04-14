using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public void playNewGame()
    {
        SceneManager.LoadScene("World_1");
    }
    public void world2()
    {
        SceneManager.LoadScene("World 2 P1");
    }
    public void world3()
    {
        SceneManager.LoadScene("World_1");
    }


}
