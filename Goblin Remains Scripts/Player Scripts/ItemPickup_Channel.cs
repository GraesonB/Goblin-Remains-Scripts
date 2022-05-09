using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GraesonBergen
{
    [CreateAssetMenu]
    public class ItemPickup_Channel : ScriptableObject
    {
        public UnityAction<int> OnEventRaised;

        public void RaiseEvent(int itemID)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(itemID);
        }
    }
}
