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

    public static int health = 12;

    public GameObject spike;
    public AIPath selfPath;
    public AIDestinationSetter selfDest;

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
            attackTime += Time.deltaTime;
            if(attackTime > attackHold)
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

    public void Attack()
    {
        Transform pl = GameObject.Find("Player").transform;
        Transform bo = GameObject.Find("CactusBody").transform;
        float pos = bo.localPosition.x - pl.localPosition.x;
        if(pos < 0)
        {
            isPlayerRight = true;
        }
        else
        {
            isPlayerRight = false;
        }
        //TODO: ACTUALLY ATTACK THE PLAYER
    }

    public void ShootSpike()
    {
        Vector3 parent = GameObject.FindGameObjectWithTag("Boss2").transform.localPosition;
        Quaternion rot = Quaternion.Euler(0,0,Random.Range(0, 359));
        GameObject spikeForce;
        spikeForce = Instantiate(spike, parent, rot);
        spikeForce.GetComponent<Rigidbody2D>().AddForce(transform.forward * 800); // test this number
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
                GameObject.Find("Player").GetComponent<SheildBash>().RestoreMovment();
            }
        }
    }
}
