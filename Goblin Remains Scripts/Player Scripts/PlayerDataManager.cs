using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class PlayerDataManager : MonoBehaviour
    {
        [SerializeField]
        PlayerStatsSO _playerStats;
        [SerializeField]
        ItemPickup_Channel _itemPickup_Channel;
        [SerializeField]
        TakeDamage_Channel _playerTakeDamage_Channel;
        [SerializeField]
        VoidEvent_Channel _playerDie_Channel;

        private void Awake()
        {
            _playerTakeDamage_Channel.OnEventRaised += TakeDamage;

        }

        private void TakeDamage(int damage, int projectileID)
        { 
            _playerStats.CurrentHealth -= damage;
            Debug.Log("current player health: " + _playerStats.CurrentHealth);
            if (_playerStats.CurrentHealth <= 0)
            {
                _playerDie_Channel.RaiseEvent();
                gameObject.SetActive(false);
            }

            
        }
    }
}
