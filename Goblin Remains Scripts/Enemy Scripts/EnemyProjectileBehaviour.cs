using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class EnemyProjectileBehaviour : MonoBehaviour
    {
        [SerializeField]
        TakeDamage_Channel _playerTakeDamage_Channel;
        [SerializeField]
        int _projectileID;
        [SerializeField]
        int _damage;

        Vector3 _zeroVector = new Vector3 (0, 0, 0);

        private void Start()
        {
            Invoke(nameof(Die), 7f);
        }


        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.layer == 7)
            {
                
                if (!collider.gameObject.GetComponent < PlayerStateMachine>().IsIntangible)
                    _playerTakeDamage_Channel.RaiseEvent(_projectileID, _damage);
            }
            

            Die();

        }

        public void Die()
        {
            Destroy(gameObject);
        }
       
    }
}
