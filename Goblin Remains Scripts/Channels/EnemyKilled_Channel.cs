using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GraesonBergen
{
    [CreateAssetMenu]
    public class EnemyKilled_Channel : ScriptableObject
    {
        public UnityAction<Vector3> OnEventRaised;

        public void RaiseEvent(Vector3 enemyPosition)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(enemyPosition);
        }

    }
}
