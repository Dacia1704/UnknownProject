
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
        OnHit();
        OnDash();
        OnIdle();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (playerStateMachine.Player.PlayerInputManager.BackwardInput) {
            Move(playerStateMachine.Player.PlayerInputManager.MovementInput,(float)playerStateMachine.Player.PlayerStats.Speed/10,true);
        }
        else {
            Move(playerStateMachine.Player.PlayerInputManager.MovementInput,(float)playerStateMachine.Player.PlayerStats.Speed/10);
        }

    }

    public override void Exit()
    {
        base.Exit();
        ResetVelocity();
        playerStateMachine.Player.playerAnimationManager.SetFloatValueAnimation(playerPropertiesSO.MoveTrigger,-1);
    }

    private void UpdateMoveAnimation() {
        float x = playerStateMachine.Player.playerAnimationManager.GetFloatValueAnimation(playerPropertiesSO.MoveTrigger);
        if(playerStateMachine.Player.PlayerInputManager.BackwardInput && x!=1) {
            playerStateMachine.Player.playerAnimationManager.SetFloatValueAnimation(playerPropertiesSO.MoveTrigger,1);
        } else if( !playerStateMachine.Player.PlayerInputManager.BackwardInput && x!=0) {
            playerStateMachine.Player.playerAnimationManager.SetFloatValueAnimation(playerPropertiesSO.MoveTrigger,0);
        }
    }
}