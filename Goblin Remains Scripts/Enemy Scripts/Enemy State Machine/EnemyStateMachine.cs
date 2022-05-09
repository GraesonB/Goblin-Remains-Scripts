using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GraesonBergen
{
    public class EnemyStateMachine : MonoBehaviour
    {
        [Header("Scriptable Objects")]
        [SerializeField]
        EnemyStatsSO _enemyStats;
        [SerializeField]
        WorldDataSO _worldData;
        [SerializeField]
        AudioEvent_Channel _audioEvent_Channel;
        [SerializeField]
        AnimationEvent_Channel _cast_Channel;
        [SerializeField]
        GameObject _iceSpell;
        [SerializeField]
        GameObject _ragdoll;


        [Header("Enemy Type")]
        [SerializeField]
        bool _isIceWizard, _isFireWizard;

        [Header("Other Data")]
        [SerializeField]
        float _spellCooldown;
        [SerializeField]
        float _attackRange;


        Transform _targetTransform;
        Rigidbody _rb;
        Collider _collider;
        Animator _animator;
        AudioSource _audioSource;
        WizardProjectileSpawner _projectileSpawner;
        NavMeshAgent _agent;


        // Getters and setters
        public Animator Animator { get { return _animator; } }
        public int FireCastHash { get { return _fireCastHash; } }
        public int IceCastHash { get { return _iceCastHash; } }
        public int IsWalkingHash { get { return _isWalkingHash; } }
        public int HitHash { get { return _hitHash; } }

        public Transform Target { get { return _targetTransform; } }
        public bool IsIceWizard { get { return _isIceWizard; } }
        public bool IsFireWizard { get { return _isFireWizard; } }


        private Vector3 _adjust;
        private Vector3 _lookDirection;
        private Vector3 _targetVector;


        // Hashes for optimization
        private int _fireCastHash;
        private int _isWalkingHash;
        private int _iceCastHash;
        private int _hitHash;

        public bool _hitStun = false;
        private bool  _playerInAttackRange;
        private bool _offCooldown = false;
        private bool _isCasting = false;

        private void Awake()
        {
            // Create an instance of the enemy controller.
            _rb = GetComponent<Rigidbody>();
            _audioSource = GetComponent<AudioSource>();
            _animator = GetComponentInChildren<Animator>();
            _fireCastHash = Animator.StringToHash("fireCast");
            _iceCastHash = Animator.StringToHash("iceCast");
            _isWalkingHash = Animator.StringToHash("isWalking");
            _hitHash = Animator.StringToHash("hit");

            _projectileSpawner = GetComponent<WizardProjectileSpawner>();
            _agent = GetComponent<NavMeshAgent>(); 

            // Setup states

            _cast_Channel.AnimationEvent += FireCast;

        }

        private void Start()
        {
            _targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
            Invoke(nameof(ResetCooldown), 4f);


        }

        void Update()
        {
            _playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, 7);

            if (_playerInAttackRange && _offCooldown)
            {
                if (_isFireWizard)
                {
                    FireCast();
                    _isCasting = true;
                }

                if (_isIceWizard)
                {
                    IceCast();
                    _isCasting = true;
                }
            }
            else if (_hitStun)
            {
                _agent.SetDestination(transform.position);
            }
            else if (_isCasting)
            {
                _agent.SetDestination(transform.position);
            }
            else
            {
                _animator.SetBool(_isWalkingHash, true);
                ChasePlayer();
            }

            gameObject.transform.LookAt(_targetTransform);

            CheckFalling();
        }

        void ChasePlayer()
        {
            _agent.SetDestination(_targetTransform.position);
        }

        public void FireCast()
        {
            _agent.SetDestination(transform.position);
            _offCooldown = false;
            Invoke(nameof(ResetCooldown), _spellCooldown);
            _animator.SetTrigger(_fireCastHash);
           
        }

        public void IceCast()
        {
            _agent.SetDestination(transform.position);
            _offCooldown = false;
            Invoke(nameof(ResetCooldown), _spellCooldown);
            _animator.SetTrigger(_iceCastHash);

        }

        public void SpawnFire()
        {
            _targetVector = _targetTransform.position;
            _projectileSpawner.Shotgun(_targetVector, 0f);
        }

        public void SpawnIce()
        {
            _targetVector = _targetTransform.position;
            GameObject newIceSpell = Instantiate(_iceSpell, _targetVector, Quaternion.identity);
        }

        void ResetCooldown()
        {
            _offCooldown = true;
        }

        public void ExitHitStun()
        {
            _hitStun = false;
        }

        public void EndCast()
        {
            _isCasting = false;
        }

        public void HitStunAnimation()
        {
            if (!_isCasting)
            {
                _animator.SetTrigger(_hitHash);
                _hitStun = true;
            }
        }

        private void CheckFalling()
        {
            if (transform.position.y < -4f)
            {
                Destroy(gameObject);
            }
        }

        public void Die()
        {
            GameObject ragdoll = Instantiate(_ragdoll, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}