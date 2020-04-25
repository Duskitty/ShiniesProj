using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_3_Idle : StateMachineBehaviour
{
   //  OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.Find("Gnome").GetComponent<Boss>().SetWalk(animator);
        //when the state is started wait three seconds or so then have the boss follow the player
        
        
    }
   
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       animator.ResetTrigger("Walk");
    
    }
}
   

