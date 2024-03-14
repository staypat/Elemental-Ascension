using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // bool isSwinging;
    // bool Idle;
    public GameObject player;
    Animator animator;
    private PlayerAttack attackScript;

    void Start()
    {
        animator = GetComponent<Animator>();
        attackScript = player.GetComponent<PlayerAttack>();
    }

    void Update()
    {
        if (attackScript != null)
        {
            if (attackScript.Attacking)
            {
                animator.SetBool("IsSwinging", true);
                animator.SetTrigger("Swing");
                animator.SetBool("IsSwinging", false);
                attackScript.Attacking = false;
            }
            if (attackScript.Parrying)
            {
                animator.SetBool("IsParrying", true);
                animator.SetTrigger("Parry");
                animator.SetBool("IsParrying", false);
                attackScript.Parrying = false;
            }
        }
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   // override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   //{
   //   animator.SetBool("Idle", true);
   //}

   //// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   //{
   //if (Input.GetMouseButtonDown(0)) // Left Click
   //{
   //   Debug.Log("OnStateEnter called: SWINGING STARTED!");
   //   // animator.SetTrigger("Swing");
   //   // isSwinging = true;
   //   animator.SetBool("isSwinging", true);
   //   animator.SetBool("Idle", false);
   //   }       
   //}

   //// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   //{
   //   Debug.Log("OnStateExit called: SWINGING FINISHED!");
   //   // animator.ResetTrigger("Swing");
   //   // isSwinging = false;
   //   animator.SetBool("isSwinging", false);
   //   animator.SetBool("Idle", true);

      
   //}

   //// OnStateMove is called right after Animator.OnAnimatorMove()
   //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   //{
   //   // Implement code that processes and affects root motion
   //}

   //// OnStateIK is called right after Animator.OnAnimatorIK()
   //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   //{
   //   // Implement code that sets up animation IK (inverse kinematics)
   //}



}
