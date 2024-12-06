using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAttack : StateMachineBehaviour
{
    public float attackTime;
    public float attackSpeed;
    private float timer = 0f;
    private float direction;
    private Rigidbody2D rb;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        direction = playerTransform.position.x - animator.transform.position.x;
        direction = direction / Mathf.Abs(direction);
        animator.SetBool("Walk", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.velocity = new Vector2(direction * attackSpeed, rb.velocity.y);
        timer += Time.deltaTime;
        if(timer > attackTime)
        {
            animator.SetBool("Walk", true);
            timer = 0;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Walk", false);
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
