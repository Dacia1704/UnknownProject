using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemyStateMachine.Enemy.EnemyAnimationController.PlayAnimation(enemyStateMachine.Enemy.EnemyPropertiesSO.IdleAnimationName);
    }

    public override void Update()
    {
        base.Update();
        OnDeath();
        OnHit();
        OnAttack();
        OnMove();
    }
    
}