using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSV : MonoBehaviour
{
    [Header("Moving")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _extraJumpValue;

    [Header("Ground check")] 
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _whatIsGround;
    
    private Vector2 _moveInput;
    private int _extraJump;
    private bool _isGrounded;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _extraJump = _extraJumpValue;
    }

    private void Update()
    {
        if (_isGrounded)
        {
            _extraJump = _extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _extraJump > 0)
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
            _extraJump--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _extraJump == 0 && _isGrounded)
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
        }
    }

    private void FixedUpdate()
    {
        _moveInput.x = Input.GetAxis("Horizontal");

        Rotation(_moveInput.x);
        
        _rigidbody.gravityScale = 1;
                
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _whatIsGround);
        
        _rigidbody.velocity = new Vector2(_moveInput.x * _speed, _rigidbody.velocity.y);
    }

    void Rotation(float direction)
    {
        Quaternion rot = transform.rotation;
        
        if (direction < 0)
        {
            rot.y = 0;
        }
        if (direction > 0)
        {
            rot.y = 180;
        }
        
        transform.rotation = rot;
    }
}
