using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Controllers
{
    public class PlayerInputReader : MonoBehaviour
    {
        private PlayerInputActions _playerControls;
        private InputAction _moveAction;
        private InputAction _jumpAction;
        private PlayerController _playerMovement;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerController>();
            _playerControls = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _moveAction = _playerControls.Player.Movement;
            _jumpAction = _playerControls.Player.Jump;
            _moveAction.Enable();
            _jumpAction.Enable();
            _jumpAction.started += StartJump;
            _jumpAction.canceled += StopJump;
            _moveAction.started += StartMove;
            _moveAction.canceled += StoptMove;
        }
        private void OnDisable()
        {
            _moveAction.Disable();
            _jumpAction.Disable();
        }
        public void StartMove(InputAction.CallbackContext context)
        {
                _playerMovement.Direction = context.ReadValue<float>();
        }
        private void StoptMove(InputAction.CallbackContext obj)
        {
            _playerMovement.Direction = 0;
        }
        public void StartJump(InputAction.CallbackContext context)
        {
            _playerMovement.IsJumpPressing = true;
        }
        private void StopJump(InputAction.CallbackContext obj)
        {
            _playerMovement.IsJumpPressing = false;
            _playerMovement.JumpButtonWasPressed = false;
        }
        
    }
}
