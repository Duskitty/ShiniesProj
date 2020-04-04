using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour
{
    public GameObject heart1, heart2, heart3, chargedGem1, chargedGem2, chargedGem3; //, gameOver;
    public static int health;
    public static int charges;

    void Start()
    {
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);

        charges = 3;
        chargedGem1.gameObject.SetActive(false);
        chargedGem2.gameObject.SetActive(false);
        chargedGem3.gameObject.SetActive(false);

        // gameOver.gameObject.SetActive(false);
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

        if (charges > 3)
            charges = 3;

       
    }
}
