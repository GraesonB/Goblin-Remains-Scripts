using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GraesonBergen
{
    [CreateAssetMenu]
    public class TakeDamage_Channel : ScriptableObject
    {
        public UnityAction<int, int> OnEventRaised;

        public void RaiseEvent(int projectileID, int damage)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(projectileID, damage);
        }
    }
}
