using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    private PlayerControls inputs;
    private Rigidbody2D rb;
    private Animator animator;
    private int jumps = 2;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 5f;

    void OnEnable() {
        inputs.Enable();
        inputs.Player.Jump.performed += Jump;
    }

    void OnDisable() {
        inputs.Disable();
        inputs.Player.Jump.performed -= Jump;
    }

    // Start is called before the first frame update
    void Awake() {
        inputs = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        Move(inputs.Player.Move.ReadValue<Vector2>());
    }

    private void Move(Vector2 movementDirection) {
        rb.velocity = new Vector2(movementDirection.x * speed, rb.velocity.y);
        if(movementDirection.x == 0) animator.SetBool("Walking", false);
        else {
            animator.SetBool("Walking", true);
            if(movementDirection.x < 0) this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            else this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void Jump(InputAction.CallbackContext ctx) {
        if(jumps > 0) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);
            jumps--;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground") {
            jumps = 2;
            animator.SetBool("Jumping", false);
        }
    }
}