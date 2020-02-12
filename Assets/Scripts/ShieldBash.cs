using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBash : MonoBehaviour
{
    
    public int maxHeath = 100;//both variables used for the enemy heath
    int currentHeath;
    private void Start()
    {
        currentHeath = maxHeath;
    }
    //public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;

    public LayerMask enemyLayers;

    public int attackDamage = 100;
    // Update is called once per frame
    void FixedUpdate()
    {
       if(Input.GetKey(KeyCode.Space))
        {
         
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("D1");
        //Play attack animation
        //animator.SetTrigger("Attack");

        //Detect enemies in rangle of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Debug.Log("D2");
        //Damage Them
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            //   enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            TakeDamage(attackDamage, enemy);
         
        }
    }
    
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    void TakeDamage(int damage, Collider2D enemy)//takes the current enemy and applies damage to it, if the current heath <=0 then destroy  the object 
    {

        currentHeath -= damage;
        //play the hurt animation
        if (currentHeath <= 0) {
            //play death animation 
            Destroy(enemy);
        
        }

    }
}

