using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_3_Walk : StateMachineBehaviour
{
    public float speed;
    public float attackRange;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Boss is in the stop range" + BossFollow.isInStopDistnace);
        if (BossFollow.isInStopDistnace==true) {
            int ran = Random.Range(0, 2);//gives a value 0-1
            if (ran == 0)
            {
                animator.SetTrigger("Ice Attack");
            }
            else if (ran == 1) {
                animator.SetTrigger("Fire Attack");

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
