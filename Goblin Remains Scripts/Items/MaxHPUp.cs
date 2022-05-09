using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class MaxHPUp : MonoBehaviour
    {
        int _itemID = 1;

        [SerializeField]
        ItemPickup_Channel _itemPickup_Channel;
        [SerializeField]
        PlayerStatsSO _playerStats;
        [SerializeField]
        int _buffSize;

        public int ItemID { get { return _itemID; } }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 7)
            {
                _itemPickup_Channel.RaiseEvent(_itemID);
                _playerStats.UpdateMaxHealth(_buffSize);
                Destroy(gameObject);
                Debug.Log("Max HP Up!");
                Debug.Log("Current max HP: " + _playerStats.CurrentMaxHealth);
            }
        }
    }
}