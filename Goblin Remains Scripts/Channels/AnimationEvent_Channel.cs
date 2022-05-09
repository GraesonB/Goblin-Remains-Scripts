using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GraesonBergen
{
    [CreateAssetMenu]
    public class AnimationEvent_Channel : ScriptableObject
    {
        public UnityAction AnimationEvent;

        public void RaiseEvent()
        {
            if (AnimationEvent != null)
                AnimationEvent.Invoke();
            
        }

    }
}
