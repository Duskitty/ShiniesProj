using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_3_Idle : StateMachineBehaviour
{
    Boss boss;
   //  OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.Find("Gnome").GetComponent<Boss>().SetWalk(animator);
        
        
    }
   
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.Find("Gnome").GetComponent<Boss>().SetWalk(animator);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.ResetTrigger("Walk");
    
    }
}
   

