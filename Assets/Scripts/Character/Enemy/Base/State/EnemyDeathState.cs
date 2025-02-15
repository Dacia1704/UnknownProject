public class EnemyDeathState: EnemyState
{
    public EnemyDeathState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemyStateMachine.Enemy.EnemyAnimationManager.PlayAnimation(enemyStateMachine.Enemy.EnemyPropertiesSO.DieAnimationName);
        enemyStateMachine.Enemy.DeathStart();
    }

    public override void Update()
    {
        base.Update();
        if (enemyStateMachine.Enemy.EnemyAnimationManager.IsAnimationEnded(
                enemyStateMachine.Enemy.EnemyPropertiesSO.DieAnimationName, 0))
        {
            enemyStateMachine.Enemy.DeathEnd();
        }
    }
}