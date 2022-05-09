using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class MoveSpeedUp : MonoBehaviour
    {
        int _itemID = 0;

        [SerializeField]
        ItemPickup_Channel _itemPickup_Channel;
        [SerializeField]
        PlayerStatsSO _playerStats;
        [SerializeField]
        float _buffSize;

        public int ItemID { get { return _itemID; } }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 7)
            {
                _itemPickup_Channel.RaiseEvent(_itemID);
                _playerStats.UpdateMoveSpeed(_buffSize);
                Destroy(gameObject);
                Debug.Log("Movement Speed Up!");
                Debug.Log("Current move speed: " + _playerStats.CurrentMoveSpeed);
            }
        }
    }
}