using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
  private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
      if (!GameObject.Find("SunPatch00").GetComponent<SunlightTrigger>().inSunlight /* && shield set to fire && button pressed*/)
      {
        player.transform.GetChild(10).GetComponent<castBeam>().castFire();
        player.transform.GetChild(10).GetComponent<castBeam>().disableLight();
      }
    }
}
