using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class AreaOfEffect : MonoBehaviour
    {
        [Header("Channels")]
        [SerializeField]
        BombExplosion_Channel _bombExplosion_Channel;

        [SerializeField]
        GameObject _explosion;
        [SerializeField]
        float _radius;
        [SerializeField]
        float _damage;
        [SerializeField]
        float _knockback;

        private bool _canExplode = false;
        private Vector3 _effectCenter;

        private void Start()
        {
            Invoke(nameof(EnableExplosion), 0.8f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_canExplode)
            {
                _effectCenter = gameObject.transform.position;
                gameObject.SetActive(false);
                _bombExplosion_Channel.RaiseEvent(_effectCenter);
                Explode();
                GameObject explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
                Invoke(nameof(ExplodeRagDoll), 0.03f);
                Invoke(nameof(Die), 0.04f);
            }
            

            
        }
        private void Explode()
        {

            Collider[] colliders = Physics.OverlapSphere(_effectCenter, _radius);
            foreach (Collider collider in colliders)
            {

                if (collider.gameObject.layer == 6)
                {
                    collider.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(_damage);
                    Vector3 knockbackDirection = (collider.gameObject.transform.position - _effectCenter);
                    float inverseMagnitude = (1 / knockbackDirection.magnitude) + 1;
                    // we aren't normalizing, and we are inverting the vector to increase the knockback closer to the center of the explosion
                    knockbackDirection.Normalize();
                    collider.gameObject.GetComponent<Rigidbody>().AddForce(knockbackDirection * _knockback * inverseMagnitude * 10, ForceMode.Impulse);
                }
       
            }

        }

        private void ExplodeRagDoll()
        {
            Debug.Log("YUPYUPYUYPU");
            Collider[] colliders = Physics.OverlapSphere(_effectCenter, _radius);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.layer == 15)
                {
                    Vector3 knockbackDirection = (collider.gameObject.transform.position - _effectCenter);
                    float inverseMagnitude = (1 / knockbackDirection.magnitude) + 1;
                    // we aren't normalizing, and we are inverting the vector to increase the knockback closer to the center of the explosion
                    knockbackDirection.Normalize();
                    collider.gameObject.GetComponent<Rigidbody>().AddForce(knockbackDirection * _knockback * inverseMagnitude, ForceMode.Impulse);
                }
            }
          
        }

        private void EnableExplosion()
        {
            _canExplode = true;
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
