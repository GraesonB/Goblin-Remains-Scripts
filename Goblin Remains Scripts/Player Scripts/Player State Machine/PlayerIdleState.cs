using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

        public override void EnterState()
        {
            _ctx.Animator.SetBool(_ctx.IsRunningHash, false);
            _ctx.CanMove = true;
        }

        public override void UpdateState()
        {
            CheckSwitchStates();
        }

        public override void ExitState()
        {
       
        }

        public override void CheckSwitchStates()
        {
            if (_ctx.IsMovementPressed)
            {
                SwitchState(_factory.Run());
            }

        }

    }
}