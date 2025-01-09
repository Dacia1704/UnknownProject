using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        ResetVelocity();
        PlayerStateMachine.player.playerRigidbody.freezeRotation = true;
        PlayerStateMachine.player.PlayerAnimationController.SetBoolValueAnimation(playerPropertiesSO.IdleBoolTrigger,true);
    }

    public override void Update()
    {
        base.Update();
        OnDash();
        OnMove();
    }

    public override void Exit()
    {
        base.Exit();
        PlayerStateMachine.player.playerRigidbody.constraints &= ~RigidbodyConstraints.FreezeRotationY;
        PlayerStateMachine.player.PlayerAnimationController.SetBoolValueAnimation(playerPropertiesSO.IdleBoolTrigger,false);
    }
}