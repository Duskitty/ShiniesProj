using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour
{
    public GameObject heart1, heart2, heart3, chargedGem1, chargedGem2, chargedGem3, unchargedGem1, unchargedGem2, unchargedGem3; //, gameOver;
    public static int health;
    public static int charges;
    


    void Start()
    {
       

        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);

        /*
        charges = 3;
        chargedGem1.gameObject.SetActive(true);
        chargedGem2.gameObject.SetActive(true);
        chargedGem3.gameObject.SetActive(true);

        unchargedGem1.gameObject.SetActive(false);
        unchargedGem2.gameObject.SetActive(false);
        unchargedGem3.gameObject.SetActive(false);
        */
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name; // World 1
        if (sceneName == "World_1")
        {
            charges = 0;
        }
        if(sceneName == "World_1_Boss") // World 1 Boss 
        {
            charges = 0;
        }
        else if (sceneName == "World 2 P1") // "World_2"
        {
            charges = 1;
        }
        else if (sceneName == "World 2 P2") // "World_2"
        {
            charges = 1;
        }
        /*
        else if (sceneName == "World_3")
        {
            charges = 2;
        }
        else if (sceneName == "World_4")
        {
            charges = 3;
        }
        */


    }
    void Update()
    {
        if (health > 3)
            health = 3;

        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                // gameOver.gameObject.SetActive(true);
                Time.timeScale = 0; // makes game stop when all 3 lives are lost
                break;
                



        }
        //testing things

        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "World_1")// "World_1" is what it will be using, but for test purposes using this other scene
        {
            charges = 0;
            unchargedGem1.gameObject.SetActive(false);
            unchargedGem2.gameObject.SetActive(false);
            unchargedGem3.gameObject.SetActive(false);
            chargedGem1.gameObject.SetActive(false);
            chargedGem2.gameObject.SetActive(false);
            chargedGem3.gameObject.SetActive(false);
        }
        else if (sceneName == "World_1_Boss") //
        {
            charges = 0;
            unchargedGem1.gameObject.SetActive(false);
            unchargedGem2.gameObject.SetActive(false);
            unchargedGem3.gameObject.SetActive(false);
            chargedGem1.gameObject.SetActive(false);
            chargedGem2.gameObject.SetActive(false);
            chargedGem3.gameObject.SetActive(false);
        }
        else if (sceneName == "World 2 P1")//do to change the name before final build
        {
            if (charges > 1)
                charges = 1;

            switch (charges)
            {
                case 0:
                    chargedGem1.gameObject.SetActive(false);
                    chargedGem2.gameObject.SetActive(false);
                    chargedGem3.gameObject.SetActive(false);
                    unchargedGem1.gameObject.SetActive(true);
                    unchargedGem2.gameObject.SetActive(false);
                    unchargedGem3.gameObject.SetActive(false);
                    break;
                case 1:
                    chargedGem1.gameObject.SetActive(true);
                    chargedGem2.gameObject.SetActive(false);
                    chargedGem3.gameObject.SetActive(false);
                    unchargedGem1.gameObject.SetActive(false);
                    unchargedGem2.gameObject.SetActive(false);
                    unchargedGem3.gameObject.SetActive(false);
                    break;
            }
        }
        else if (sceneName == "World 2 P2")//do to change the name before final build
        {
            if (charges > 1)
                charges = 1;

            switch (charges)
            {
                case 0:
                    chargedGem1.gameObject.SetActive(false);
                    chargedGem2.gameObject.SetActive(false);
                    chargedGem3.gameObject.SetActive(false);
                    unchargedGem1.gameObject.SetActive(true);
                    unchargedGem2.gameObject.SetActive(false);
                    unchargedGem3.gameObject.SetActive(false);
                    break;
                case 1:
                    chargedGem1.gameObject.SetActive(true);
                    chargedGem2.gameObject.SetActive(false);
                    chargedGem3.gameObject.SetActive(false);
                    unchargedGem1.gameObject.SetActive(false);
                    unchargedGem2.gameObject.SetActive(false);
                    unchargedGem3.gameObject.SetActive(false);
                    break;
            }
        }
            /*
        }
        else if (sceneName == "World_3")
        {
            if (charges > 2)
            charges = 2;
         case 0:
                chargedGem1.gameObject.SetActive(false);
                chargedGem2.gameObject.SetActive(false);
                chargedGem3.gameObject.SetActive(false);
                unchargedGem1.gameObject.SetActive(true);
                unchargedGem2.gameObject.SetActive(true);
                unchargedGem3.gameObject.SetActive(true);
                break;
            case 1:
                chargedGem1.gameObject.SetActive(true);
                chargedGem2.gameObject.SetActive(false);
                chargedGem3.gameObject.SetActive(false);
                unchargedGem1.gameObject.SetActive(false);
                unchargedGem2.gameObject.SetActive(true);
                unchargedGem3.gameObject.SetActive(true);
                break;
            case 2:
                chargedGem1.gameObject.SetActive(true);
                chargedGem2.gameObject.SetActive(true);
                chargedGem3.gameObject.SetActive(false);
                unchargedGem1.gameObject.SetActive(false);
                unchargedGem2.gameObject.SetActive(false);
                unchargedGem3.gameObject.SetActive(true);
                break;

        }
        else if (sceneName == "World_4")
        {
            if (charges > 3)
            charges = 3;
        case 0:
                chargedGem1.gameObject.SetActive(false);
                chargedGem2.gameObject.SetActive(false);
                chargedGem3.gameObject.SetActive(false);
                unchargedGem1.gameObject.SetActive(true);
                unchargedGem2.gameObject.SetActive(true);
                unchargedGem3.gameObject.SetActive(true);
                break;
            case 1:
                chargedGem1.gameObject.SetActive(true);
                chargedGem2.gameObject.SetActive(false);
                chargedGem3.gameObject.SetActive(false);
                unchargedGem1.gameObject.SetActive(false);
                unchargedGem2.gameObject.SetActive(true);
                unchargedGem3.gameObject.SetActive(true);
                break;
            case 2:
                chargedGem1.gameObject.SetActive(true);
                chargedGem2.gameObject.SetActive(true);
                chargedGem3.gameObject.SetActive(false);
                unchargedGem1.gameObject.SetActive(false);
                unchargedGem2.gameObject.SetActive(false);
                unchargedGem3.gameObject.SetActive(true);

                break;
            case 3:
                chargedGem1.gameObject.SetActive(true);
                chargedGem2.gameObject.SetActive(true);
                chargedGem3.gameObject.SetActive(true);
                unchargedGem1.gameObject.SetActive(false);
                unchargedGem2.gameObject.SetActive(false);
                unchargedGem3.gameObject.SetActive(false);

                break;
        }
        */
        
    }

}