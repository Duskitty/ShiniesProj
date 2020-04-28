using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class B2Script : MonoBehaviour
{

    public int spikes; // random number that dictates the number of spikes that'll get released
    public static bool fightBegin = false; // begins fight
    public static bool startTrack = false; // begins tracking
    public bool isPlayerRight; // for use with the Attack. sees if the player is to the right of the boss

    public static float invin; // invincibility time for player
    public float attackTime; // time since last attack
    public int attackHold; //max time before next attack
    public float spikeTime; // time since last spike
    public int spikeHold; // max time before next spike
    public float handTime;

    public static int health = 25;

    public GameObject spike;
    public AIPath selfPath;
    public AIDestinationSetter selfDest;
    public GameObject hand;

    // Start is called before the first frame update
    void Start()
    {
        invin = 0f;
        attackTime = 0f;
        attackHold = 4;
        spikes = 1;
        spikeTime = 0f;
        spikeHold = 3;
        isPlayerRight = false;
        selfPath = GetComponent<AIPath>();
        selfDest = GetComponent<AIDestinationSetter>();
        handTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(startTrack == true)
        {
            selfPath.enabled = true;
            selfDest.enabled = true;
            //startTrack = false;
        }
        if(fightBegin == true)
        {
            if(invin > 0)
            {
                invin -= Time.deltaTime;
            }
            if(handTime > 0)
            {
                handTime -= Time.deltaTime;
                if(handTime <= 0)
                {
                    ResetHand();
                }
            }
            attackTime += Time.deltaTime;
            if(attackTime > attackHold && handTime <= 0)
            {
                attackTime = 0f;
                Attack();
            }
            spikeTime += Time.deltaTime;
            if(spikeTime > spikeHold)
            {
                spikeTime = 0f;
                ShootSpike();
            }
        }
    }
    //FOR A LATER DAY, MAKE THE BOSS ATTACK & SHOOT MORE SPIKES WITH LOWER HP
    public void Attack()
    {
        Transform pl = GameObject.Find("Player").transform;
        Transform bo = GameObject.Find("CactusBody").transform;
        float pos = bo.localPosition.x - pl.localPosition.x;
        if(pos < 0)
        {
            isPlayerRight = true;
            hand = GameObject.Find("CactusRightArm2");
        }
        else
        {
            isPlayerRight = false;
            hand = GameObject.Find("CactusLeftArm2");
        }
        hand.GetComponent<AIPath>().maxSpeed = 4;
        handTime = 1f;
    }

    public void ResetHand()
    {
        hand.GetComponent<AIPath>().maxSpeed = 2;
    }

    public void ShootSpike()
    {
        Vector3 parent = transform.localPosition;
        int theRange = Random.Range(0, 3) * 90;
        Quaternion rot = Quaternion.Euler(0,0,theRange);
        GameObject spikeForce;
        spikeForce = Instantiate(spike, parent, rot);
        Rigidbody2D boi = spikeForce.GetComponent<Rigidbody2D>();
        if(theRange == 0)
        {
            boi.AddForce(transform.up * 4, ForceMode2D.Impulse);
        }
        else if(theRange == 90)
        {
            boi.AddForce(transform.right * -4, ForceMode2D.Impulse);
        }
        else if(theRange == 180)
        {
            boi.AddForce(transform.up * -4, ForceMode2D.Impulse);
        }
        else if(theRange == 270)
        {
            boi.AddForce(transform.right * 4, ForceMode2D.Impulse);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (invin > 0)
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
                //GameObject.Find("Player").GetComponent<SheildBash>().RestoreMovment();
            }
        }
    }
}
