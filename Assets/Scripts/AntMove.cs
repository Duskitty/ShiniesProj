using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMove : MonoBehaviour
{
    private float horizontal = 0f;
    private float vertical = 0f;
    public Animator animat;
    public float Delay;
    public bool isShieldBahsing = false;

    void Update()
    {
        if (transform.position == GetComponent<WaypointFinder>().waypoints[1].position)
        {
            animat.SetBool("Right", false);
            animat.SetBool("Moving", true);
            animat.SetBool("Left", false);
            animat.SetBool("Up", true);
            animat.SetBool("Down", false);
        }
        if (transform.position == GetComponent<WaypointFinder>().waypoints[0].position)
        {
            animat.SetBool("Right", false);
            animat.SetBool("Moving", true);
            animat.SetBool("Left", false);
            animat.SetBool("Up", false);
            animat.SetBool("Down", true);
        }
    }

}
