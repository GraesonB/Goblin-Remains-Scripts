using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GraesonBergen
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        PlayerStatsSO _playerStats;
        [SerializeField]
        WorldDataSO _worldData;

        PlayerInput _playerInput;
        CharacterController _characterController;
        Animator _animator;


        // Variables for storing player movement inputs
        private Vector3 _currentMovement;
        private Vector2 _currentMovementInput;
        private bool _isMovementPressed;
        private bool _isBasicAttackPressed;
        private Vector3 _adjust;
        private Vector3 _lookDirection;

        // Hashes for optimization
        private int _isRunningHash;

        private void Awake()
        {
            // Create an instance of the player controller.
            _playerInput = new PlayerInput();
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponentInChildren<Animator>();

            _isRunningHash = Animator.StringToHash("isRunning");

            _playerInput.Playing.Move.started += OnMovementInput;
            _playerInput.Playing.Move.canceled += OnMovementInput;
            _playerInput.Playing.Move.performed += OnMovementInput;

            _playerInput.Playing.BasicAttack.started += OnBasicAttackInput;
            _playerInput.Playing.BasicAttack.canceled += OnBasicAttackInput;


        }


        // Update is called once per frame
        void Update()
        {
            HandleGravity();
            HandleMovement();
            HandleAnimation();
            HandleRotation();
        }

        private void OnEnable()
        {
            _playerInput.Playing.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Playing.Disable();
        }

        void OnMovementInput(InputAction.CallbackContext context)
        {
            _currentMovementInput = context.ReadValue<Vector2>();
            _currentMovement.x = _currentMovementInput.x;
            _currentMovement.z = _currentMovementInput.y;

            // rotate 45 so movement is up and down relative to camera.
            _adjust = new Vector3(0, 45, 0);
            _currentMovement = Quaternion.Euler(_adjust) * _currentMovement;

            _isMovementPressed = _currentMovementInput.x != 0 || _currentMovementInput.y != 0;
        }

        void OnBasicAttackInput(InputAction.CallbackContext context)
        {
            _isBasicAttackPressed = context.ReadValueAsButton();
        }

        void HandleAnimation()
        {
            if (_isMovementPressed)
            {
                _animator.SetBool(_isRunningHash, true);
            }
            else if (!_isMovementPressed)
            {
                _animator.SetBool(_isRunningHash, false);
            }

            if (_isBasicAttackPressed)
                Debug.Log("Basic Attack");
        }

        void HandleMovement()
        {
            _characterController.Move(_currentMovement * Time.deltaTime * _playerStats.CurrentMoveSpeed);
        }

        void HandleRotation()
        {
            _lookDirection.x = _currentMovement.x;
            _lookDirection.y = 0.0f;
            _lookDirection.z = _currentMovement.z;

            Quaternion currentRotation = transform.rotation;

            if (_isMovementPressed)
            {
                Quaternion targetRotation = Quaternion.LookRotation(_lookDirection);
                transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _playerStats.CurrentRotationFactor * Time.deltaTime);
            }

        }

        void HandleGravity()
        {
            if (_characterController.isGrounded)
            {
                _currentMovement.y = _worldData.groundedGravity;
            }
            else
            {
                _currentMovement.y += _worldData.gravity;
            }
        }
    }
}