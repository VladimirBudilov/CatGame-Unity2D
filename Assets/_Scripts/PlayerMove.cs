using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Moving")] 
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _extraJumpValue;

    [Header("Ground check")] 
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _whatIsGround;
    

    private float _moveInput;
    private int _extraJump;
    private bool _facingright;
    private bool _isGrounded;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _extraJump = _extraJumpValue;
    }

    private void Update()
    {
        if (_isGrounded==true)
        {
            _extraJump = _extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.W) && _extraJump > 0)
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
            _extraJump--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && _extraJump == 0 && _isGrounded == true)
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
        }
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _whatIsGround);
        
        _moveInput = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(_moveInput * _speed, _rigidbody.velocity.y);

        if (_facingright==false && _moveInput>0)
        {
            Flip();
        }
        else if (_facingright == true && _moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        _facingright = !_facingright;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    
} 
