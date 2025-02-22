using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemyStateMachine.Enemy.EnemyAnimationManager.PlayAnimation(enemyStateMachine.Enemy.EnemyPropertiesSO.AttackAnimationName);
        attackCooldownCounter = enemyStateMachine.Enemy.EnemyPropertiesSO.AttackCooldown;
    }
    
    public override void Update()
    {
        base.Update();

        if (enemyStateMachine.Enemy.Damable.AttackableStats.Attack == 0 && enemyStateMachine.Enemy.EnemyAnimationManager.IsAnimationEnded(enemyStateMachine.Enemy.EnemyPropertiesSO.AttackAnimationName,0))
        {
            OnMove();
            OnIdle();
        }
    }
}