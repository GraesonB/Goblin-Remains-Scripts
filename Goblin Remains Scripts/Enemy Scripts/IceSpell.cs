using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class IceSpell : MonoBehaviour
    {
        [SerializeField]
        TakeDamage_Channel _playerTakeDamage_Channel;
        [SerializeField]
        float _radius;
        [SerializeField]
        int _damage;
        [SerializeField]
        PlayerStatsSO _playerStats;
        [SerializeField]
        float _slowPercent, _delay, _slowTimeLength;
        [SerializeField]
        GameObject _indicator;
        [SerializeField]
        LayerMask _overLapSphereMask;
        
        

        private Vector3 _effectCenter;
        private bool _slowActive = false;
        private bool _playerSlowed;


        private void Start()
        {
            _effectCenter = transform.position;
            StartCoroutine(IceSpellCoroutine());
        }


        private bool CheckCollisions()
        {

            Collider[] colliders = Physics.OverlapSphere(_effectCenter, _radius, _overLapSphereMask);
            foreach (Collider collider in colliders)
            {

                if (collider.gameObject.layer == 7)
                {
                    if (!collider.GetComponent<PlayerStateMachine>().IsIntangible)
                        return true;
                }
               

            }
            return false;
        }

        public IEnumerator IceSpellCoroutine()
        {

            GameObject indicator = Instantiate(_indicator, _effectCenter, Quaternion.identity);
            indicator.GetComponent<IndicatorBehaviour>().ScheduleDeath(_slowTimeLength);
            

            yield return new WaitForSeconds(_delay);

            GameObject indicator2 = Instantiate(_indicator, _effectCenter, Quaternion.identity);
            indicator2.GetComponent<IndicatorBehaviour>().ScheduleDeath(_slowTimeLength - _delay);

            _slowActive = true;
            Invoke(nameof(DeactivateSlow), _slowTimeLength);


            while (_slowActive)
            {
  
                if (CheckCollisions())
                {
                    if (!_playerSlowed && _playerStats.CurrentMoveSpeedMod > .5f)
                    {
                        _playerStats.UpdateMoveSpeed(-_slowPercent);
                        _playerSlowed = true;
                        Debug.Log("Player slowed");
                    }
                    yield return null;
                }
                else
                {
                    if (_playerSlowed)
                    {
                        Debug.Log("Player unslowed");
                        _playerStats.UpdateMoveSpeed(_slowPercent);
                        _playerSlowed = false;
                    }
                    yield return null;
                }

            }

            if (CheckCollisions())
            {
                _playerTakeDamage_Channel.RaiseEvent(2, 1);

            }

            if (_playerSlowed)
            {
                _playerStats.UpdateMoveSpeed(_slowPercent);
                _playerSlowed = false;
                Debug.Log("Player unslowed");
            }

            Destroy(gameObject);


        }


        private void DeactivateSlow()
        {
            _slowActive = false;
        }
    }
}
