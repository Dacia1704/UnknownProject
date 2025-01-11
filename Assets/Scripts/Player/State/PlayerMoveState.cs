
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
        if (playerStateMachine.Player.PlayerInputSystem.BackwardInput) {
            Move(playerStateMachine.Player.PlayerInputSystem.MovementInput,playerStateMachine.Player.PlayerPropertiesSO.BaseSpeed,true);
        }
        else {
            Move(playerStateMachine.Player.PlayerInputSystem.MovementInput,playerStateMachine.Player.PlayerPropertiesSO.BaseSpeed);
        }

    }

    public override void Exit()
    {
        base.Exit();
        ResetVelocity();
        playerStateMachine.Player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.MoveTrigger,-1);
    }

    private void UpdateMoveAnimation() {
        float x = playerStateMachine.Player.PlayerAnimationController.GetFloatValueAnimation(playerPropertiesSO.MoveTrigger);
        if(playerStateMachine.Player.PlayerInputSystem.BackwardInput && x!=1) {
            playerStateMachine.Player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.MoveTrigger,1);
        } else if( !playerStateMachine.Player.PlayerInputSystem.BackwardInput && x!=0) {
            playerStateMachine.Player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.MoveTrigger,0);
        }
    }
}