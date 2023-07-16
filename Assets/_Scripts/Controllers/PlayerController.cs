using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


namespace Game.InputController
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _jumpForce = 10f;
        private PlayerInputActions _playerControls;
        private InputAction _moveAction;
        private InputAction _jumpAction;
        
        private void Awake()
        {
            _playerControls = new PlayerInputActions();
        }
        
        private void Jump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Jump");
            }
        }
        
        private void OnEnable()
        {
            _playerControls.Enable();
            _moveAction = _playerControls.Player.Movement;
            _jumpAction = _playerControls.Player.Jump;
            _jumpAction.performed += Jump;
        }
        
        private void OnDisable()
        {
            _moveAction.Disable();
            _jumpAction.Disable();
        }
        
        
    }
}