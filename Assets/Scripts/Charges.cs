using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Charges : MonoBehaviour
{
     void Update()
    {
        if (Input.GetKey(KeyCode.C)) {

            GameControlScript.charges -= 1;//decrmate the charges

            if (GameControlScript.charges < 0) {
                GameControlScript.charges = 0;//make sure charges dont go below zero
            
            }
        
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        /*
        if (col.gameObject.tag.Equals("sunbeam"))
        {
            GameControlScript.charges += 1;
            if (GameControlScript.charges > 1)
            {
                GameControlScript.charges = 1; // 1 charged gem in world 2

            }
        }
        */

        // cant get this to work for each scene/ world

        if (col.gameObject.tag.Equals("sunbeam"))
        {
            // Create a temporary reference to the current scene.
            Scene currentScene = SceneManager.GetActiveScene();

            // Retrieve the name of this scene.
            string sceneName = currentScene.name;

            if (sceneName == "World_1")
            {
                GameControlScript.charges = 0; // 0 charged gem in world 1
            }
            else if (sceneName == "World 2 P1") // "World_2"
            {
                GameControlScript.charges += 1;
                if (GameControlScript.charges > 1)
                {
                    GameControlScript.charges = 1; // 1 charged gem in world 2

                }
            }
            else if (sceneName == "World 2 P2") // "World_2"
            {
                GameControlScript.charges += 1;
                if (GameControlScript.charges > 1)
                {
                    GameControlScript.charges = 1; // 1 charged gem in world 2

                }
            }
            /*
            else if (sceneName == "World_3")
            {
                GameControlScript.charges += 2;
                if (GameControlScript.charges > 2)
                {
                    GameControlScript.charges = 2; // 2 charged gem in world 3

                }
            }
            else if (sceneName == "World_4")
            {
                GameControlScript.charges += 3;
                if (GameControlScript.charges > 3)
                {
                 GameControlScript.charges = 3; // 2 charged gem in world 3

                }
            }*/
        }
        


    }
    public void BeamPress()
    {
        GameControlScript.charges -= 1;//decrmate the charges

        if (GameControlScript.charges < 0)
        {
            GameControlScript.charges = 0;//make sure charges dont go below zero

        }
    }
}
