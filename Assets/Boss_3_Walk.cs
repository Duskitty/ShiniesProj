using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_3_Walk : StateMachineBehaviour
{
    public float speed;
    public float attackRange;
    private Transform target;
    private GameObject boss;
    Random ran;
    int randNumber = 0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        boss = GameObject.FindWithTag("Boss");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       boss. transform.position = Vector2.MoveTowards(boss.transform.position, target.position, speed * Time.fixedDeltaTime);
        if (Vector2.Distance(boss.transform.position, target.position) > attackRange)
        {
            boss.transform.position = Vector2.MoveTowards(boss.transform.position, target.position, speed * Time.fixedDeltaTime);
        }
        else { 
        //attack
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Ice Attack");
        animator.ResetTrigger("Fire Attack");

    }
}
