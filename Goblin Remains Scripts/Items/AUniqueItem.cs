using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class AUniqueItem : MonoBehaviour
    {
        int _itemID = 3;

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
                Debug.Log("You picked up a seemingly useless but very unique item!");
                Destroy(gameObject);
            }
        }
    }
}