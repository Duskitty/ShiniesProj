using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class B1Script : MonoBehaviour
{
    //public bool chargeState = false;
    //public bool dustState = false;
    //public bool flyState = false;
    public static bool hit;

    public float invin; //invincibility timer
    public float switchTime; //max time before switch
    public float waiting; //time waiting between states

    public GameObject mushroom;
    public GameObject tracker;
    private GameObject trackerCopy;

    public Animator anim;
    public GameObject chargeGem;
    public static int health = 10;
    //TEST VARIABLES TO REPRESENT STATES
    public bool nullState;
    public bool chargeState;
    
    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = true;
        invin = 0f;
        switchTime = 5f;
        waiting = 0f;
        chargeGem = GameObject.Find("ChargeGem");
        hit = false;
        nullState = true;
        chargeState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (B1StartTrack.fightBegin == true)
        {
            if (invin > 0)
            {
                invin -= Time.deltaTime;
            }
            if(nullState == true)
            {
                waiting += Time.deltaTime;
            }
            if (waiting >= switchTime)
            {
                waiting = 0f;
                trackerCopy = Instantiate(tracker, GameObject.Find("Player").transform);
                GameObject.Find("Controller").GetComponent<AIDestinationSetter>().target = trackerCopy.transform;
                nullState = false;
                chargeState = true;
            }
            if(chargeState == true)
            {
                EnterCharge();
            }
            if(hit == true)
            {
                hit = false;
                chargeState = false;
                nullState = true;
                ExitCharge();

            }
            if (health <= 0)
            {
                GameObject.Find("Controller").SetActive(false);
                SpawnChargeGem.deadBoss = true;
            }

        }
    }
    
    public void EnterCharge()
    {
        GameObject.Find("Controller").GetComponent<AIPath>().maxSpeed = 3;
    }
    public void ExitCharge()
    {
        GameObject.Find("Controller").GetComponent<AIPath>().maxSpeed = 1;
        GameObject.Find("Controller").GetComponent<AIDestinationSetter>().target = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            if (SheildBash.isSheildBashing == true)
            {
                Debug.Log("boss took damage");
                health--;
                GameObject.FindGameObjectWithTag("HealthBar").transform.localScale = new Vector3((health / 10.0f), 1f, 1f);
                GameObject.Find("Player").GetComponent<SheildBash>().RestoreMovment();
                if(health == 0)
                {
                    GameObject.Find("Controller").SetActive(false);
                    SpawnChargeGem.deadBoss = true;
                }
            }
            else if (invin > 0)
            {
                Debug.Log("no damage");
                //no damage taken
            }
            else
            {
                invin = 1f;
                Debug.Log("damage");
                // no shield bash = 1 less heart
                GameControlScript.health -= 1;
                print(GameControlScript.health);
                print(col.name);
                StartCoroutine(col.GetComponent<KnockBack>().KnockCo());
            }
        }
        
    }

}
