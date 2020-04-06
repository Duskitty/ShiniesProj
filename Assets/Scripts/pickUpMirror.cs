using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickUpMirror : MonoBehaviour
{
    public GameObject sheild, beamButton, reflectGem,fireGem;
  public static bool hasSheild = false;
    private void Start()
    {
        sheild.gameObject.SetActive(false);
        beamButton.gameObject.SetActive(false);
        reflectGem.gameObject.SetActive(false);
        fireGem.gameObject.SetActive(false);
    }
    public void OnCollisionEnter2D(Collision2D thing)
  {
    Debug.Log("Picked Up the mirror!");
    hasSheild = true;
    GameObject.Find("Player").GetComponent<PlayerMovement>().animator.SetBool("HasShield", true);
    Destroy(GameObject.Find("Shield"));
        sheild.gameObject.SetActive(true);
        beamButton.gameObject.SetActive(true);
        reflectGem.gameObject.SetActive(true);

    }
    private void Update()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name; // World 1
       
        if (sceneName == "World_1_Boss") // World 1 Boss 
        {
            hasSheild = true;
            GameObject.Find("Player").GetComponent<PlayerMovement>().animator.SetBool("HasShield", true);
            sheild.gameObject.SetActive(true);
            beamButton.gameObject.SetActive(true);
            reflectGem.gameObject.SetActive(true);
        }
        else if (sceneName == "World1_Test_ForCharges") // "World_2"
        {
            hasSheild = true;
            GameObject.Find("Player").GetComponent<PlayerMovement>().animator.SetBool("HasShield", true);
            sheild.gameObject.SetActive(true);
            beamButton.gameObject.SetActive(true);
            reflectGem.gameObject.SetActive(true);
        }
        /*
        else if (sceneName == "World_3")
        {
            hasSheild = true;
        }
        else if (sceneName == "World_4")
        {
            hasSheild = true;
        }
        */


    }
}
