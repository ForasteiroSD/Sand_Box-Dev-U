using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRightState : IBaseState {
    private Rigidbody2D rb;
    private float begin = Time.time;
    private float timaWalking = 2f;
    [SerializeField] private float speed = 3f; 

    public void EnterState(EnemyStateMachine stateMachine) {
        rb = stateMachine.gameObject.GetComponent<Rigidbody2D>();
        stateMachine.GetComponent<SpriteRenderer>().flipX = false;
    }

    public void UpdateState(EnemyStateMachine stateMachine) {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if(Time.time - begin >= timaWalking) {
            rb.velocity = new Vector2(0, rb.velocity.y);
            stateMachine.SwitchState(new MovingLeftState());
        }
    }
}