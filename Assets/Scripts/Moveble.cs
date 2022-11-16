using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(SpriteRenderer))]

public class Moveble : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _jumpForse;
    private bool _isGrounded = true;
    private bool _isJumping = false;
    private Rigidbody2D _rigidebody2d;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private int _runHash = Animator.StringToHash("Run");
    private int _jumpHash = Animator.StringToHash("Jump");

    private void Awake()
    {
        _rigidebody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Run();
        StartJump();
    }

    private void Run()
    {
        float horizontalAxis = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        transform.Translate(horizontalAxis, 0, 0);

        if (horizontalAxis != 0 && _isJumping == false)
        {
            _animator.Play(_runHash);
            Debug.Log("walk");
        }
    }

    private void StartJump()
    {
        if(_isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidebody2d.AddForce(transform.up * _jumpForse, ForceMode2D.Impulse);
                _animator.Play(_jumpHash);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Ground>())
        {
            _isGrounded = true; 
            _isJumping = false;
            Debug.Log(_isJumping);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false; 
        _isJumping = true;
        Debug.Log(_isJumping);
    }
}