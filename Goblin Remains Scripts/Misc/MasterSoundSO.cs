using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    [CreateAssetMenu]
    public class MasterSoundSO : ScriptableObject
    {
        [SerializeField]
        [Range(0f, 1f)]
        public float masterVolume;

    }
}
