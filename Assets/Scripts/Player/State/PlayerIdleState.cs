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
        playerStateMachine.Player.PlayerRigidbody.freezeRotation = true;
        playerStateMachine.Player.PlayerAnimationController.SetBoolValueAnimation(playerPropertiesSO.IdleBoolTrigger,true);
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
        playerStateMachine.Player.PlayerRigidbody.constraints &= ~RigidbodyConstraints.FreezeRotationY;
        playerStateMachine.Player.PlayerAnimationController.SetBoolValueAnimation(playerPropertiesSO.IdleBoolTrigger,false);
    }
}