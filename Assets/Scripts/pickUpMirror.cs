using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (hasSheild) {
            sheild.gameObject.SetActive(true);
            beamButton.gameObject.SetActive(true);
            reflectGem.gameObject.SetActive(true);

        }
    }
}
