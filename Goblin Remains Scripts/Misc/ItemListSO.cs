using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    [CreateAssetMenu]
    public class ItemListSO : ScriptableObject
    {
        [SerializeField]
        GameObject[] _commonItems;

        [SerializeField]
        GameObject[] _uniqueItems;

        public GameObject[] CommonItems { get { return _commonItems; } }
        public GameObject[] UniqueItems { get { return _uniqueItems; } }
    }
}
