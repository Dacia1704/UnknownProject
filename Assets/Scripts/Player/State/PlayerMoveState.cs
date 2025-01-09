public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        PlayerStateMachine.player.PlayerAnimationController.SetBoolValueAnimation(playerPropertiesSO.MoveBoolTrigger,true);
    }

    public override void Update()
    {
        base.Update();
        OnDash();
        OnIdle();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Move(PlayerStateMachine.player.PlayerInputSystem.movementInput,PlayerStateMachine.player.PlayerPropertiesSO.BaseSpeed);

    }

    public override void Exit()
    {
        base.Exit();
        ResetVelocity();
        PlayerStateMachine.player.PlayerAnimationController.SetBoolValueAnimation(playerPropertiesSO.MoveBoolTrigger,false);
    }
}