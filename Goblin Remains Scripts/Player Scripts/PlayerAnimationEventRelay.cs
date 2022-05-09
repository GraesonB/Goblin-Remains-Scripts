using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class PlayerAnimationEventRelay : MonoBehaviour
    {
        [SerializeField]
        AnimationEvent_Channel _footstep_Channel;
        [SerializeField]
        AnimationEvent_Channel _throw_Channel;

        public void FootstepEvent()
        {
            _footstep_Channel.RaiseEvent();
        }

        public void ThrowEvent()
        {
            _throw_Channel.RaiseEvent();
        }



    }
}