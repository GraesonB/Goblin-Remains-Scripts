using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class WizardAnimationEventMB : MonoBehaviour
    {
        EnemyStateMachine _enemyStateMachine;

        private void Awake()
        {
            _enemyStateMachine = gameObject.GetComponentInParent<EnemyStateMachine>();
        }

        public void FireCastEvent()
        {
            _enemyStateMachine.SpawnFire();
        }

        public void IceCastEvent()
        {
            _enemyStateMachine.SpawnIce();
        }

        public void ExitHitStunEvent()
        {
            _enemyStateMachine.ExitHitStun();
        }

        public void EndCastEvent()
        {
            _enemyStateMachine.EndCast();
        }

    }
}
