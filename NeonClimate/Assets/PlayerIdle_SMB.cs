using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle_SMB : StateMachineBehaviour
{
    private bool isMoving = false;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isMoving = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            animator.SetBool("isWalking", true);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("hasJumped");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
