public class EnemyMoveState : EnemyState
{
    public EnemyMoveState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemyStateMachine.Enemy.EnemyAnimationController.SetBoolValueAnimation(enemyStateMachine.Enemy.EnemyPropertiesSO.MoveTrigger, true);
    }

    public override void Update()
    {
        base.Update();
        OnIdle();
    }

    public override void Exit()
    {
        enemyStateMachine.Enemy.EnemyAnimationController.SetBoolValueAnimation(enemyStateMachine.Enemy.EnemyPropertiesSO.MoveTrigger, false);
        base.Exit();
    }
}