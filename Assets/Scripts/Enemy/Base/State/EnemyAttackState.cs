using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemyStateMachine.Enemy.EnemyAnimationController.PlayAnimation(enemyStateMachine.Enemy.EnemyPropertiesSO.AttackAnimationName);
        attackCooldownCounter = enemyStateMachine.Enemy.EnemyPropertiesSO.AttackCooldown;
    }
    
    public override void Update()
    {
        base.Update();

        if (enemyStateMachine.Enemy.Damable.IsGetAttack == 0 && enemyStateMachine.Enemy.EnemyAnimationController.IsAnimationEnded(enemyStateMachine.Enemy.EnemyPropertiesSO.AttackAnimationName,0))
        {
            OnDeath();
            OnMove();
            OnIdle();
        }
    }
}