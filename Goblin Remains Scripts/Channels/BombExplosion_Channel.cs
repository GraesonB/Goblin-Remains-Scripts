using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GraesonBergen
{
    [CreateAssetMenu]
    public class BombExplosion_Channel : ScriptableObject
    {
        public UnityAction<Vector3> OnEventRaised;

        public void RaiseEvent(Vector3 position)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(position);
        }
    }
}
