using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string StartLevel;
    public string LevelSelect;

    public void newGame()
    {
        Application.LoadLevel(StartLevel);
    }
    public void levelSelect()
    {

        Application.LoadLevel(LevelSelect);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
