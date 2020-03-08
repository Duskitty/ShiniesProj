﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatisEnemies;
    public int damage;
    public float knockbackAmount;
    public GameObject player;
    private bool isSprint;
    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space)&&isSprint==true) {
                Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatisEnemies);//gets the enemies to put in a array to damage them
                for (int i = 0; i < enemy.Length; ++i) {//go through the above array
                    enemy[i].GetComponent<MushroomMove>().SheildBash();
                    // enemy[i].GetComponent<Enemy>().TakeDamage(damage);
                     setSprint(false);
                    Debug.Log("about to sheild bash");

                }

            }

            timeBtwAttack = startTimeBtwAttack;


        }
        else {
            timeBtwAttack -= Time.deltaTime;

        }


    }
     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    public void setSprint(bool sprint) {
        isSprint = sprint;
    }
}
