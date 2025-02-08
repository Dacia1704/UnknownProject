using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemyStateMachine.Enemy.EnemyAnimationController.SetBoolValueAnimation(enemyStateMachine.Enemy.EnemyPropertiesSO.IdleTrigger, true);
    }

    public override void Update()
    {
        base.Update();
        OnHit();
        OnMove();
    }
    

    public override void Exit()
    {
        enemyStateMachine.Enemy.EnemyAnimationController.SetBoolValueAnimation(enemyStateMachine.Enemy.EnemyPropertiesSO.IdleTrigger, false);
        base.Exit();
    }
}