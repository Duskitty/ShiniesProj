using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;
using Pathfinding;

public class B1Script : MonoBehaviour
{
    //public bool chargeState = false;
    //public bool dustState = false;
    //public bool flyState = false;
    public static bool hit = false;
    public static bool chargeHit = false;

    public B1StateControl<B1Script> stateMachine { get; set; }

    public float invin; //invincibility timer
    public float switchTime; //max time before switch
    public float waiting; //time waiting between states
    public int state;

    public GameObject mushroom;
    public GameObject tracker;
    private GameObject trackerCopy;

    public Animator anim;
    public GameObject chargeGem;
    public static int health = 12;
    
    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = true;
        invin = 0f;
        switchTime = 5f;
        waiting = 0f;
        stateMachine = new B1StateControl<B1Script>(this);
        chargeGem = GameObject.Find("ChargeGem");
        
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
            if (stateMachine.currentState == null || stateMachine.currentState == B1NullState.Instance)
            {
                waiting += Time.deltaTime;
            }
            if (waiting >= switchTime)
            {
                waiting = 0f;
                trackerCopy = Instantiate(tracker, GameObject.Find("Player").transform);
                GameObject.Find("Controller").GetComponent<AIDestinationSetter>().target = trackerCopy.transform;
                stateMachine.ChangeState(B1ChargeState.Instance);
            }
            if(chargeHit == true)
            {
                chargeHit = false;
                anim.SetBool("isFlying", true);
                stateMachine.ChangeState(B1FlyState.Instance);
            }
            if(stateMachine.currentState == B1FlyState.Instance)
            {
                waiting += Time.deltaTime;
                if(waiting >= 1.25f)
                {
                    anim.SetBool("isFlying", false);
                    waiting = 0f;
                    Instantiate(mushroom, new Vector3(Random.Range(-5, 6), Random.Range(-2, 5)), Quaternion.identity);
                    Instantiate(mushroom, new Vector3(Random.Range(-5, 6), Random.Range(-2, 5)), Quaternion.identity);
                    Instantiate(mushroom, new Vector3(Random.Range(-5, 6), Random.Range(-2, 5)), Quaternion.identity);
                    GameObject.Find("Controller").GetComponent<AIDestinationSetter>().target = GameObject.Find("Player").transform;
                    stateMachine.ChangeState(B1NullState.Instance);
                }
            }
            if (health <= 0)
            {
                GameObject.Find("Controller").SetActive(false);
                
            }

            stateMachine.Update();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        hit = true;
        if (col.gameObject.CompareTag("Player"))
        {
            if (SheildBash.isSheildBashing == true)
            {
                Debug.Log("boss took damage");
                health--;
                GameObject.FindGameObjectWithTag("HealthBar").transform.localScale = new Vector3((health / 12.0f), 1f, 1f);
                if(health == 0)
                {
                    GameObject.Find("Controller").SetActive(false);
                }
            }
            else if (invin > 0 || B1ChargeState.stunned == true)
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
