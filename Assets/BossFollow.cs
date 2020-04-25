using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollow : MonoBehaviour
{
    Animator animator;
    private Transform target;
    public float speed=3;
    public float stopDistance=3;
    public static bool isInStopDistnace = false;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        animator = GameObject.Find("Gnome").GetComponent<Animator>();
        GetComponent<BossFollow>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            isInStopDistnace = false;

            //bool to have set to determine if the boss is in the stop distance 
            //is true the boss can attack 
        }
        else {
            isInStopDistnace = true;
        }
    }

}
