using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : IBaseState {
    private Animator animator;
    private float begin = Time.time;
    private float timaAttacking = 2f;
    public void EnterState(EnemyStateMachine stateMachine) {
        animator = stateMachine.gameObject.GetComponent<Animator>();
        animator.SetBool("Attacking", true);
    }

    public void UpdateState(EnemyStateMachine stateMachine) {
        if(Time.time - begin >= timaAttacking) {
            animator.SetBool("Attacking", false);
            stateMachine.SwitchState(new MovingRightState());
        }
    }
}