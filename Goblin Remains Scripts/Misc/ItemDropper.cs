using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class ItemDropper : MonoBehaviour
    {
        [SerializeField]
        EnemyKilled_Channel _enemyKilled_Channel;
        [SerializeField]
        float _dropChance = 50;
        [SerializeField]
        float _uniqueChance = 30;
        [SerializeField]
        ItemListSO _itemList;

        private GameObject[] _uniqueItemList;
        private GameObject[] _commonItemList;

        private int _dropRoll;
        private int _uniqueRoll;
        private int _randomIdx;


        private void Awake()
        {
            _enemyKilled_Channel.OnEventRaised += DropItem;

            _uniqueItemList = _itemList.UniqueItems;
            _commonItemList = _itemList.CommonItems;
        }

        private void DropItem(Vector3 dropLocation)
        {
            _dropRoll = Random.Range(0, 100);
            if (_dropRoll <= _dropChance)
            {
                dropLocation.y = 0.5f;
                _uniqueRoll = Random.Range(0, 100);
                if (_uniqueRoll <= _uniqueChance)
                {

                    Instantiate(ChooseUnique(), dropLocation, Quaternion.identity);
                }
                else
                {
                    Instantiate(ChooseCommon(), dropLocation, Quaternion.identity);
                }
            }
        }

        private GameObject ChooseUnique()
        {
            _randomIdx = Random.Range(0, _uniqueItemList.Length);
            return _uniqueItemList[_randomIdx];
        }

        private GameObject ChooseCommon()
        {
            _randomIdx = Random.Range(0, _commonItemList.Length);
            return _commonItemList[_randomIdx];
        }
    }
}
