using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveBackBash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").GetComponent<SheildBash>().enabled = true;
        GameObject.Find("BashButton").SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
