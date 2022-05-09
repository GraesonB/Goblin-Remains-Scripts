using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class EnemyHealthManager : MonoBehaviour
    {
        [SerializeField]
        EnemyStatsSO _enemyStats;
        [SerializeField]
        EnemyKilled_Channel _enemyKilled_Channel;

        private float _currentHealth;
        EnemySoundRequester _soundRequester;
        EnemyStateMachine _stateMachine;


        private void Awake()
        {
            _currentHealth = _enemyStats.CurrentHealth;
            _soundRequester = gameObject.GetComponent<EnemySoundRequester>();
            
        }

        private void Start()
        {
            _stateMachine = GetComponent<EnemyStateMachine>();
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            _soundRequester.PlayEnemyHit();
            _stateMachine.HitStunAnimation();
            
            if (_currentHealth <= 0)
            {
                _enemyKilled_Channel.RaiseEvent(gameObject.transform.position);
                _stateMachine.Die();

                
            }
        }

        
    }
}
