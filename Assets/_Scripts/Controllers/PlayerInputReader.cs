using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Controllers
{
    public class PlayerInputReader : MonoBehaviour
    {
        private PlayerInputActions _playerControls;
        private InputAction _moveAction;
        private InputAction _jumpAction;
        private PlayerController _playerMovementComponent;

        private void Awake()
        {
            _playerMovementComponent = GetComponent<PlayerController>();
            _playerControls = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _playerControls.Enable();
            _moveAction = _playerControls.Player.Movement;
            _jumpAction = _playerControls.Player.Jump;
            _jumpAction.performed += Jump;
            _moveAction.performed += Move;
        }
        
        private void OnDisable()
        {
            _moveAction.Disable();
            _jumpAction.Disable();
        }
        public void Move(InputAction.CallbackContext context)
        {
            Debug.Log("Move");
            _playerMovementComponent.Direction = context.ReadValue<float>();
        }

        public void Jump(InputAction.CallbackContext context)
        {
            Debug.Log("Jump");
            if (context.started)
            {
                Debug.Log("Jump started");
                _playerMovementComponent.IsJumpPressing = true;
            }

            if (context.canceled)
            {
                Debug.Log("Jump canceled");
                _playerMovementComponent.IsJumpPressing = false;
                _playerMovementComponent.JumpButtonWasPressed = false;
            }
        }
    }
}
