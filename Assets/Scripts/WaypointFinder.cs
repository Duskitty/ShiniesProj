using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFinder: MonoBehaviour
{
    //Array of waypoints from which the enemy walks from one to the next one
    [SerializeField]
    private Transform[] waypoints;
    //movement speed
    [SerializeField]
    private float moveSpeed = 2f;
    //index of current waypoint
    private int wpIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[wpIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //WHEN REFLECTION & STUN IS IMPLEMENTED, HAVE AN IF STATEMENT TO SEE IF THE ENEMY IS STUNNED
        //print(wpIndex);
        //move enemy towards next waypoint
        if (wpIndex < waypoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[wpIndex].transform.position, moveSpeed * Time.deltaTime);
            if (transform.position == waypoints[wpIndex].transform.position)
            {
                if (wpIndex == 0)
                {
                    wpIndex = 1;
                }
                else
                {
                    wpIndex = 0;
                }

            }
        }
    }
}
