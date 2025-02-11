public class EnemyDeathState: EnemyState
{
    public EnemyDeathState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemyStateMachine.Enemy.EnemyAnimationController.PlayAnimation(enemyStateMachine.Enemy.EnemyPropertiesSO.DieAnimationName);
        
        enemyStateMachine.Enemy.Damable.transform.gameObject.SetActive(false);
        enemyStateMachine.Enemy.Attackable.transform.gameObject.SetActive(false);
    }
}