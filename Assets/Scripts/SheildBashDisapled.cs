using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildBashDisapled : MonoBehaviour
{
    public GameObject bash;
    // Start is called before the first frame update
    void Start()
    {
        //to do get rid of this just a temp fix
        GameObject.Find("Player").GetComponent<SheildBash>().enabled = false;//to do delete me after sprint on 4-7-2020
        bash.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
