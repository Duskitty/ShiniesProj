using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_3_Walk : StateMachineBehaviour
{
    public float speed;
    public float attackRange;

    Transform player;
    Rigidbody2D rb;
    Boss boss;
    Random ran;
    int randNumber = 0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            randNumber = Random.Range(0, 1);
            if (randNumber == 0)
            {
                animator.SetTrigger("Fire Attack");
            }
            else
            {
                animator.SetTrigger("Ice Attack");
            }
          
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Ice Attack");
        animator.ResetTrigger("Fire Attack");

    }
}
