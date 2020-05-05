using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickUpMirror : MonoBehaviour
{
    public GameObject sheild, beamButton, reflectGem, bashbutton;
    public static bool hasSheild; 
    private GameObject mirror;

    private void Start()
    {
        sheild.gameObject.SetActive(false);
        beamButton.gameObject.SetActive(false);
        reflectGem.gameObject.SetActive(false);
        bashbutton.gameObject.SetActive(false);
        mirror = GameObject.Find("Shield");
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name; // World 1
        if (sceneName == "World_1")
        {
            hasSheild = false;
        }
        else
        {
            hasSheild = true;
            GameObject.Find("Player").GetComponent<PlayerMovement>().animator.SetBool("HasShield", true);
        }
    }
    public void OnCollisionEnter2D(Collision2D thing)
    {
        //if (thing.gameObject.name == "Sheild")
        //{
            //Debug.Log("Picked Up the mirror!");
            hasSheild = true;
            GameObject.Find("Player").GetComponent<PlayerMovement>().animator.SetBool("HasShield", true);
            Destroy(mirror);
            if (sheild != null)
            {
              sheild.gameObject.SetActive(true);
            }
            beamButton.gameObject.SetActive(true);
            reflectGem.gameObject.SetActive(true);
            bashbutton.gameObject.SetActive(true);
        //}

    }
   
    private void Update()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name; // World 1
       
        if (sceneName != "World_1") 
        {
            hasSheild = true;
            GameObject.Find("Player").GetComponent<PlayerMovement>().animator.SetBool("HasShield", true);
            if (sheild != null)
            {
              sheild.gameObject.SetActive(true);
            }
            beamButton.gameObject.SetActive(true);
            reflectGem.gameObject.SetActive(true);
            bashbutton.gameObject.SetActive(true);
        }
    }
}
