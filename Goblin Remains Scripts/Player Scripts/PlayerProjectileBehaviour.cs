using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class PlayerProjectileBehaviour : MonoBehaviour
    {
        [SerializeField]
        float _lifespan;
        [SerializeField]
        float _damage;
        [SerializeField]
        float _knockback;

        Vector3 _velocity;
        float _torqueFloat1;
        float _torqueFloat2;
        float _torqueFloat3;

        private void Start()
        {
            Invoke(nameof(Die), _lifespan);
            _velocity = gameObject.GetComponent<Rigidbody>().velocity.normalized;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == 6)
            {
                EnemyHealthManager enemyHP = collision.gameObject.GetComponent<EnemyHealthManager>();
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                EnemyStateMachine sm = collision.gameObject.GetComponent<EnemyStateMachine>();
                sm.HitStunAnimation();
                enemyHP.TakeDamage(_damage);
                rb.AddForce(_velocity * _knockback, ForceMode.Impulse);
                _torqueFloat1 = Random.Range(-30f, 30f);
                _torqueFloat2 = Random.Range(-30f, 30f);
                _torqueFloat3 = Random.Range(-30f, 30f);
                Vector3 _torque = new Vector3(_torqueFloat1, _torqueFloat2, _torqueFloat3);
                rb.AddTorque(_torque);

                Destroy(gameObject);
            }
            
        }

        private void Die()
        {
            Destroy(gameObject);
        }

    }
}
