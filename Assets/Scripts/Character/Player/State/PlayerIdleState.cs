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
        playerStateMachine.Player.Rigidbody.freezeRotation = true;
        playerStateMachine.Player.playerAnimationManager.SetBoolValueAnimation(playerPropertiesSO.IdleBoolTrigger,true);
    }

    public override void Update()
    {
        base.Update();
        OnHit();
        OnDash();
        OnMove();
    }

    public override void Exit()
    {
        base.Exit();
        playerStateMachine.Player.Rigidbody.constraints &= ~RigidbodyConstraints.FreezeRotationY;
        playerStateMachine.Player.playerAnimationManager.SetBoolValueAnimation(playerPropertiesSO.IdleBoolTrigger,false);
    }
}