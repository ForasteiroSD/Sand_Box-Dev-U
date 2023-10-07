using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spRenderer;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpHeight = 2.5f;
    [SerializeField] private float _fallGravityScaleMultiplier = 3f;
    [SerializeField] private float _timeToJump = .15f;
    private GameObject _ground;
    private bool _canJump = true;
    private float _gravityScale;
    private float _fallGravityScale;
    private float _jumpForce;
    private bool _isJumping = false;
    private int _lookingDirection; //-1 -> left, 1 -> right
    public int lookingDirection => _lookingDirection;
    
    private void Awake() {
        //GetComponents
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spRenderer = GetComponent<SpriteRenderer>();

        //Jump
        _gravityScale = _rb.gravityScale;
        _fallGravityScale = _rb.gravityScale * _fallGravityScaleMultiplier;
        _rb.gravityScale = _fallGravityScale;
        _ground = transform.GetChild(0).gameObject;

        //Move
        _lookingDirection = 1;
    }

    private void Update() {
        //Move
        if(Input.GetAxis("Horizontal") != 0) Move(Input.GetAxis("Horizontal"));
        else _animator.SetBool("Walking", false);
        
        //Jump
        if(Input.GetKeyDown(KeyCode.W) && _canJump) Jump();
        if(_isJumping) {
            if(_rb.velocity.y >= 1.7f && Input.GetKeyUp(KeyCode.W)) {
                _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y/2);
                _rb.gravityScale = _fallGravityScale;
            }
            if(_rb.velocity.y < 1.7f) {
                _rb.gravityScale = _fallGravityScale;
                _isJumping = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        //Reset canJump
        if(collider.tag == "Ground") {
            _canJump = true;
            _animator.SetBool("Jumping", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        //Cancel canJump
        if(gameObject.activeInHierarchy && collider.tag == "Ground") StartCoroutine(CancelCanJump());
    }

    private void Move(float moveDirection) {
        _animator.SetBool("Walking", true);
        _rb.velocity = new Vector2(moveDirection * _speed, _rb.velocity.y);
        if(moveDirection > 0) {
            _lookingDirection = 1;
            _spRenderer.flipX = false;
        } else if(moveDirection < 0) {
            _lookingDirection = -1;
            _spRenderer.flipX = true;
        }
    }

    private void Jump() {
        _animator.SetBool("Jumping", true);
        _rb.gravityScale = _gravityScale;
        _jumpForce = (float) Math.Sqrt(_jumpHeight * (Physics2D.gravity.y * _rb.gravityScale) * -2) *_rb.mass;
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _isJumping = true;
        _canJump = false;
    }

    IEnumerator CancelCanJump() {
        yield return new WaitForSeconds(_timeToJump);
        _canJump = false;
    }
}