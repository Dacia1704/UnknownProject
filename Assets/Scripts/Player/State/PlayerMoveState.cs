
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }


    public override void Update()
    {
        base.Update();
        UpdateMoveAnimation();
        OnDash();
        OnIdle();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (PlayerStateMachine.player.PlayerInputSystem.BackwardInput) {
            Move(PlayerStateMachine.player.PlayerInputSystem.MovementInput,PlayerStateMachine.player.PlayerPropertiesSO.BaseSpeed,true);
        }
        else {
            Move(PlayerStateMachine.player.PlayerInputSystem.MovementInput,PlayerStateMachine.player.PlayerPropertiesSO.BaseSpeed);
        }

    }

    public override void Exit()
    {
        base.Exit();
        ResetVelocity();
        PlayerStateMachine.player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.MoveTrigger,-1);
    }

    private void UpdateMoveAnimation() {
        float x = PlayerStateMachine.player.PlayerAnimationController.GetFloatValueAnimation(playerPropertiesSO.MoveTrigger);
        if(PlayerStateMachine.player.PlayerInputSystem.BackwardInput && x!=1) {
            PlayerStateMachine.player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.MoveTrigger,1);
        } else if( !PlayerStateMachine.player.PlayerInputSystem.BackwardInput && x!=0) {
            PlayerStateMachine.player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.MoveTrigger,0);
        }
    }
}