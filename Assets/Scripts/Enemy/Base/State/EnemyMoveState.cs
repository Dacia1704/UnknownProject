using UnityEngine;

public class EnemyMoveState : EnemyState
{
    public EnemyMoveState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemyStateMachine.Enemy.EnemyAnimationController.SetBoolValueAnimation(enemyStateMachine.Enemy.EnemyPropertiesSO.MoveTrigger, true);
    }

    public override void Update()
    {
        base.Update();
        OnHit();
        OnIdle();
        
    }
    
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (enemyStateMachine.Enemy.EnemyAI.ShouldChase)
        {
            ChasePlayer();
        }
    }

    public virtual void ChasePlayer()
    {
        Vector3 direction = (enemyStateMachine.Enemy.Player.transform.position - enemyStateMachine.Enemy.transform.position).normalized;
        direction.y = 0;
        enemyStateMachine.Enemy.Rigidbody.velocity = direction * enemyStateMachine.Enemy.EnemyPropertiesSO.BaseStats.Speed;
        enemyStateMachine.Enemy.transform.LookAt(enemyStateMachine.Enemy.Player.transform.position);
    }

    public override void Exit()
    {
        enemyStateMachine.Enemy.EnemyAnimationController.SetBoolValueAnimation(enemyStateMachine.Enemy.EnemyPropertiesSO.MoveTrigger, false);
        base.Exit();
    }
}