using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChargeGem : MonoBehaviour
{
    public static bool deadBoss;
    public GameObject chargeGem;

    // Start is called before the first frame update
    void Start()
    {
        deadBoss = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(deadBoss == true)
        {
            chargeGem.SetActive(true);
            deadBoss = false;
        }
    }
}
