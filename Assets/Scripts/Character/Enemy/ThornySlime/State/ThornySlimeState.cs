using UnityEngine;

public class ThornySlimeState: EnemyState
{
    protected ThornySlimeStateMachine thornySlimeStateMachine => (ThornySlimeStateMachine)enemyStateMachine;
    public ThornySlimeState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }


    protected override void OnHit()
    {
        if (enemyStateMachine.Enemy.Damable.AttackableStats.Attack != 0 && !thornySlimeStateMachine.ThornySlime.ThornySlimeAI.ShouldDefend)
        {
            enemyStateMachine.ChangeState(enemyStateMachine.EnemyHitState);
        }
    }

    protected override void OnIdle()
    {
        if(!(enemyStateMachine.Enemy.Rigidbody.velocity.x < -0.1f || enemyStateMachine.Enemy.Rigidbody.velocity.x > 0.1f ||
             enemyStateMachine.Enemy.Rigidbody.velocity.z < -0.1f || enemyStateMachine.Enemy.Rigidbody.velocity.z > 0.1f)) {
            enemyStateMachine.ChangeState(thornySlimeStateMachine.ThornySlimeIdleState);
        }
    }

    protected override void OnMove()
    {
        if(enemyStateMachine.Enemy.EnemyAI.ShouldChase) {
            enemyStateMachine.ChangeState(thornySlimeStateMachine.ThornySlimeIdleState);
        }
    }
    public virtual void OnDefend()
    {
        if (thornySlimeStateMachine.ThornySlime.ThornySlimeAI.ShouldDefend)
        {
            thornySlimeStateMachine.ChangeState(thornySlimeStateMachine.ThornySlimeDefendState);
        }
    }
}