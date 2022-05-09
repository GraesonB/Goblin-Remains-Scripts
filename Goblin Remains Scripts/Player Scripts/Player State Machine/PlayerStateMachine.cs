using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GraesonBergen
{
    public class PlayerStateMachine : MonoBehaviour
    {
        [Header("Scriptable Objects")]
        [SerializeField]
        PlayerStatsSO _playerStats;
        [SerializeField]
        WorldDataSO _worldData;
        [SerializeField]
        AudioEvent_Channel _audioEvent_Channel;
        [SerializeField]
        AnimationEvent_Channel _throw_Channel;
        [SerializeField]
        VoidEvent_Channel _bombThrow_Channel;
        [SerializeField]
        TakeDamage_Channel _takeDamage_Channel;
        [SerializeField]
        VoidEvent_Channel _specialHold;
        [SerializeField]
        MousePositionSO _mousePosition;
        [SerializeField]
        PlayerInputSO _playerInputSO;
        [SerializeField]
        GameObject _rockInHand;

        [Header("Other Data")]
        [SerializeField]
        float _chargeTime;
        [SerializeField]
        float _basicAttackCooldown;


        ProjectileSpawner _projectileSpawner;
        Lob _bombLob;
        PlayerInput _playerInput;
        CharacterController _characterController;
        Animator _animator;

        // State variables
        PlayerBaseState _currentState;
        PlayerStateFactory _states;

        // Getters and setters
        public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
        public bool CanMove { get { return _canMove; } set { _canMove = value; } }
        public bool IsMovementPressed { get { return _isMovementPressed; } }
        public bool IsBasicAttackPressed { get { return _isBasicAttackPressed; } }
        public Animator Animator { get { return _animator; } }
        public bool IsCurrentlyAttacking { get { return _isCurrentlyAttacking; } }
        public int IsRunningHash { get { return _isRunningHash; } }
        public int PressHash { get { return _pressHash; } }
        public int ReleaseHash { get { return _releaseHash; } }
        public int ThrowHash { get { return _releaseHash; } }
        public PlayerInput PlayerInput { get { return _playerInput; } }
        public bool IsIntangible { get { return _isIntangible; } }

        // Variables for storing player movement inputs
        private Vector3 _currentMovement;
        private Vector2 _currentMovementInput;
        private bool _isMovementPressed;
        private bool _isBasicAttackPressed;
        private bool _isBombSpecialPressed;
        private bool _canMove;
        private Vector3 _adjust;
        private Vector3 _lookDirection;

        // Hashes for optimization
        private int _isRunningHash;
        private int _pressHash;
        private int _releaseHash;
        private int _throwHash;

        // Attack variables?
        private Vector3 _throwTarget;
        private bool _basicAttackReady = true;
        private bool _bombSpecialReady = true;
        private bool _isCurrentlyAttacking = false;
        private bool _charged;

        private bool _isIntangible = false;

        private void Awake()
        {
            // Create an instance of the player controller.
            _playerInput = _playerInputSO.playerInput;
            _characterController = GetComponent<CharacterController>();
            _projectileSpawner = GetComponent<ProjectileSpawner>();
            _bombLob = GetComponent<Lob>();
            _animator = GetComponentInChildren<Animator>();
            _isRunningHash = Animator.StringToHash("isRunning");
            _pressHash = Animator.StringToHash("press");
            _releaseHash = Animator.StringToHash("release");
            _throwHash = Animator.StringToHash("throw");


            // Setup states
            _states = new PlayerStateFactory(this);
            _currentState = _states.Idle();
            _currentState.EnterState();

            _throw_Channel.AnimationEvent += Throw;
            _takeDamage_Channel.OnEventRaised += TakeDamage;

            _playerInput.Playing.Move.started += OnMovementInput;
            _playerInput.Playing.Move.canceled += OnMovementInput;
            _playerInput.Playing.Move.performed += OnMovementInput;

            _playerInput.Playing.BasicAttack.started += OnBasicAttackInput;
            _playerInput.Playing.BasicAttack.canceled += OnBasicAttackInput;

            _playerInput.Playing.BombSpecial.started += OnBombSpecialInput;
            _playerInput.Playing.BombSpecial.canceled += OnBombSpecialInput;


        }

        private void OnEnable()
        {
            _playerInput.Playing.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Playing.Disable();
        }

        void Update()
        {
            HandleGravity();
            HandleMovement();
            HandleRotation();
            HandleBasicAttack();
            HandleBombSpecial();
            _currentState.UpdateState();
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

        void OnBombSpecialInput(InputAction.CallbackContext context)
        {
            _isBombSpecialPressed = context.ReadValueAsButton();
        }

        void HandleMovement()
        {
            if (_canMove)
                _characterController.Move(_currentMovement * Time.deltaTime * _playerStats.CurrentMoveSpeed);
        }

        void HandleBasicAttack()
        {
            if (_basicAttackReady && _isBasicAttackPressed)
            {
                _basicAttackReady = false;
                _isCurrentlyAttacking = true;

                StartCoroutine(BasicAttackCoroutine());
            }
        }

        void HandleBombSpecial()
        {
            if (_bombSpecialReady && _isBombSpecialPressed)
            {
                _bombSpecialReady = false;
                _isCurrentlyAttacking = true;
                StartCoroutine(BombSpecialCoroutine());

            }
        }

        IEnumerator BasicAttackCoroutine()
        {
            _charged = false;
            Invoke(nameof(ChargeThrow), _chargeTime);
            _animator.SetTrigger(_pressHash);
            _rockInHand.SetActive(true);

            while (_isBasicAttackPressed)
            {

                yield return null;
            }
            if (!_charged)
            {

                _animator.SetTrigger(_releaseHash);

            }
            else
            {
                Invoke(nameof(DeactivateRockInHand), 0.05f);
                _animator.SetTrigger(_throwHash);
                _throwTarget = _mousePosition.MousePosition;
                _throwTarget.y = _projectileSpawner.ProjectileOrigin.position.y;
            }
            Invoke(nameof(ExitAttackState), _basicAttackCooldown / 2);
            Invoke(nameof(ResetBasicAttack), _basicAttackCooldown);
        }

        IEnumerator BombSpecialCoroutine()
        {

            _specialHold.RaiseEvent();
            while (_isBombSpecialPressed)
            {
                yield return null;
            }
            _specialHold.CancelEvent();
            _throwTarget = _mousePosition.MousePosition;
            _throwTarget.y = 0;
            ThrowBomb();
            Invoke(nameof(ExitAttackState), _basicAttackCooldown / 2);
            Invoke(nameof(ResetBombSpecial), _playerStats.BombSpecialCooldown);
        }

        void HandleRotation()
        {
            if (_isCurrentlyAttacking)
            {
                _lookDirection.x = _mousePosition.MousePosition.x - transform.position.x;
                _lookDirection.y = 0.0f;
                _lookDirection.z = _mousePosition.MousePosition.z - transform.position.z;
            }
            else
            {
                _lookDirection.x = _currentMovement.x;
                _lookDirection.y = 0.0f;
                _lookDirection.z = _currentMovement.z;
            }

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

        void TakeDamage(int yup, int useless)
        {
            Debug.Log("Intangible");
            _isIntangible = true;
            Invoke(nameof(ResetIntangibility), 1f);
        }

        public void Throw()
        {
            _projectileSpawner.SpawnProjectile(_throwTarget);
        }

        public void ThrowBomb()
        {
            _bombThrow_Channel.RaiseEvent();
            _bombLob.LobIt(_throwTarget);
        }

        public void ResetBasicAttack()
        {
            _basicAttackReady = true;
        }

        public void ResetBombSpecial()
        {

            _bombSpecialReady = true;
        }

        public void ExitAttackState()
        {
            _isCurrentlyAttacking = false;
        }

        private void ChargeThrow()
        {
            _charged = true;
        }

        private void ResetIntangibility()
        {
            _isIntangible = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == 8)
            {
                Debug.Log("ran into bullet");
                if (!_isIntangible)
                {
                    _takeDamage_Channel.RaiseEvent(0, 1);

                }
                collision.gameObject.GetComponent<EnemyProjectileBehaviour>().Die();
            }
        }

        private void DeactivateRockInHand()
        {
            _rockInHand.SetActive(false);
        }

    }
}