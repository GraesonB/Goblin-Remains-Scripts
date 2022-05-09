using UnityEngine;

namespace GraesonBergen
{
    public class PlayerRunState : PlayerBaseState
    {
        public PlayerRunState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

        public override void EnterState()
        {
            _ctx.Animator.SetBool(_ctx.IsRunningHash, true);

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
            if (!_ctx.IsMovementPressed)
            {
                SwitchState(_factory.Idle());
            }

        }

    }
}
