using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class PlayerAnimationEventMB : MonoBehaviour
    {
        private PlayerStateMachine _parentStateMachine;


        void Awake()
        {
            _parentStateMachine = GetComponentInParent<PlayerStateMachine>();
        }

        void BasicAttackEvent()
        {
            _parentStateMachine.Throw();
        }
    }
}

