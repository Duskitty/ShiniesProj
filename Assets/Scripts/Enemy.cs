using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("D2");

        //play hurt animation

        if (currentHealth <= 0)
        {
            Die();
        }

        void Die()
        {

            // die animation

            //disable enemy
            Destroy(gameObject);
        }
    }


    



    




}
