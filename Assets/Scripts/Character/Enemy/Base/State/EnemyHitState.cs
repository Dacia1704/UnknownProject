using UnityEngine;

public class EnemyHitState: EnemyState
{
    public EnemyHitState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemyStateMachine.Enemy.Damable.GetDamage(ref enemyStateMachine.Enemy.EnemyStats.Health,enemyStateMachine.Enemy.Damable.IsGetAttack);
        enemyStateMachine.Enemy.OnHealthDamaged.Invoke(enemyStateMachine.Enemy.EnemyStats.Health);

        if (enemyStateMachine.Enemy.EnemyStats.Health <= 0)
        {
            enemyStateMachine.ChangeState(enemyStateMachine.EnemyDeathState);
        }
        else
        {
            enemyStateMachine.Enemy.EnemyAnimationController.PlayAnimation(enemyStateMachine.Enemy.EnemyPropertiesSO.HitAnimationName);
        }
        
        enemyStateMachine.Enemy.Damable.ResetIsGetAttack();
        
    }
    
    public override void Update()
    {
        base.Update();

        if (enemyStateMachine.Enemy.Damable.IsGetAttack == 0 && enemyStateMachine.Enemy.EnemyAnimationController.IsAnimationEnded(enemyStateMachine.Enemy.EnemyPropertiesSO.HitAnimationName,0))
        {
            OnDeath();
            OnAttack();
            OnMove();
            OnIdle();
        }
    }

}