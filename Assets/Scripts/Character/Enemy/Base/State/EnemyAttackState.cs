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
        OnHit();
        if (enemyStateMachine.Enemy.EnemyAnimationManager.IsAnimationEnded(enemyStateMachine.Enemy.EnemyPropertiesSO.AttackAnimationName,0))
        {
            OnMove();
            OnIdle();
            OnAttack();
        }
    }
}