using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveBackBash : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bashButton;
    void Start()
    {
        GameObject.Find("Player").GetComponent<SheildBash>().enabled = true;
        bashButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
