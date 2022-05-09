using UnityEngine;
using UnityEngine.Events;

namespace GraesonBergen
{
    [CreateAssetMenu]
    public class VoidEvent_Channel : ScriptableObject
    {
        public UnityAction OnEventRaised, OnEventCanceled;

        public void RaiseEvent()
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke();
        }

        public void CancelEvent()
        {
            if (OnEventCanceled != null)
            {
                OnEventCanceled.Invoke();
            }
        }
    }
}