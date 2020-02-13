using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public int knockBackAmount = 0;
   public Rigidbody2D rb;
    private bool isKnockBack = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        KnockBack();//apply knock back to the player
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
    void KnockBack() {
        isKnockBack = true;
        rb.AddForce(new Vector2(-knockBackAmount, 0f));
        rb.AddForce(new Vector2(0f, 0f));        
    }
}
