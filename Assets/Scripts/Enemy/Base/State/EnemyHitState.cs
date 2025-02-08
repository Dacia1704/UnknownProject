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
        Debug.Log("Enemy Hit State " + enemyStateMachine.Enemy.EnemyStats.Health);
        
    }
    
    public override void Update()
    {
        base.Update();

        if (enemyStateMachine.Enemy.Damable.IsGetAttack == 0)
        {
            OnMove();
            OnIdle();
        }
    }

}