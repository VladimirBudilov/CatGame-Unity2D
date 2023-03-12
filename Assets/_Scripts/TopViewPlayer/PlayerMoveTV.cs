using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTV : MonoBehaviour
{
    [Header("Moving")]
    [SerializeField] private float _speed;

    private Vector2 _moveInput;
    private Rigidbody2D _rigidbody;

    private KeyCode[] _codes = new KeyCode[] {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D}; 
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        _rigidbody.gravityScale = 0;
    }
    private void FixedUpdate()
    {
        _moveInput.x = Input.GetAxis("Horizontal");
        _moveInput.y = Input.GetAxis("Vertical");

        //Rotation();
        
        _rigidbody.MovePosition(_rigidbody.position + _moveInput * (_speed * Time.fixedDeltaTime));
    }

    //void Rotation()
    //{
    //    if (expr)
    //    {
    //        
    //    }
    //}
}
