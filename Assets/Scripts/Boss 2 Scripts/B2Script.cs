using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class B2Script : MonoBehaviour
{

    public int spikes; // random number that dictates the number of spikes that'll get released

    public static float invin; // invincibility time for player
    public float attackTime; // time since last attack
    public int attackHold; //max time before next attack
    public float spikeTime; // time since last spike
    public int spikeHold; // max time before next spike

    public static int health = 12;

    public GameObject spike;

    // Start is called before the first frame update
    void Start()
    {
        invin = 0f;
        attackTime = 0f;
        attackHold = 4;
        spikes = 1;
        spikeTime = 0f;
        spikeHold = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(B2StartTrack.fightBegin == true)
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

    }

    public void ShootSpike()
    {
        Vector3 parent = GameObject.FindGameObjectWithTag("Boss2").transform.localPosition;
        Quaternion rot = Quaternion.Euler(0,0,Random.Range(0, 359));
        GameObject spikeForce;
        spikeForce = Instantiate(spike, parent, rot);
        spikeForce.GetComponent<Rigidbody2D>().AddForce(transform.forward * 100); // test this number
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (SheildBash.isSheildBashing == true) // TODO: change this to fire damage
            {
                Debug.Log("boss took damage");
                health--;
                GameObject.FindGameObjectWithTag("HealthBar").transform.localScale = new Vector3((health / 12.0f), 1f, 1f);
                GameObject.Find("Player").GetComponent<SheildBash>().RestoreMovment();
                if (health == 0)
                {
                    GameObject.Find("Controller").SetActive(false);
                }
            }
            else if (invin > 0) // TODO: add stun functionality to boss
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
