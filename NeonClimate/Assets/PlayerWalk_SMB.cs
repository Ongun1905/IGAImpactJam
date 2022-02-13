using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk_SMB : StateMachineBehaviour
{
    private PlayerController playerController;
    private Rigidbody2D rb2d;
     //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb2d = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        
    }

     //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        playerController.Flip();
        if(playerController.IsGrounded())
        {
            playerController.Movement();
        }
        


        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.Space) && playerController.IsGrounded())
        {
        
            animator.SetTrigger("hasJumped");

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
