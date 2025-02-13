using UnityEngine;

public abstract class EnemyState : IState
{
    protected EnemyStateMachine enemyStateMachine;

    protected float attackCooldownCounter;
    public EnemyState(EnemyStateMachine enemyStateMachine) {
        this.enemyStateMachine = enemyStateMachine;
    }
    public virtual void Enter()
    {
        // Debug.Log("State: " + GetType().Name);
        attackCooldownCounter = 0;
    }

    public virtual void Exit()
    {
    }

    public virtual void PhysicsUpdate()
    {
        if (attackCooldownCounter > 0)
        {
            attackCooldownCounter -= Time.fixedDeltaTime;
        } 
    }

    public virtual void Update()
    {
    }

    protected virtual void OnIdle() {
         if(!(enemyStateMachine.Enemy.Rigidbody.velocity.x < -0.1f || enemyStateMachine.Enemy.Rigidbody.velocity.x > 0.1f ||
        enemyStateMachine.Enemy.Rigidbody.velocity.z < -0.1f || enemyStateMachine.Enemy.Rigidbody.velocity.z > 0.1f)) {
            enemyStateMachine.ChangeState(enemyStateMachine.EnemyIdleState);
        }
    }

    protected virtual void OnMove() {
        if(enemyStateMachine.Enemy.EnemyAI.ShouldChase) {
            enemyStateMachine.ChangeState(enemyStateMachine.EnemyMoveState);
        }
    }

    protected virtual void OnAttack()
    {
        if (enemyStateMachine.Enemy.EnemyAI.ShouldAttack && attackCooldownCounter<=0)
        {
            enemyStateMachine.ChangeState(enemyStateMachine.EnemyAttackState);
        }
    }

    protected virtual void OnHit()
    {
        if (enemyStateMachine.Enemy.Damable.IsGetAttack != 0)
        {
            enemyStateMachine.ChangeState(enemyStateMachine.EnemyHitState);
        }
    }

    protected virtual void OnDeath()
    {
        if (enemyStateMachine.Enemy.EnemyStats.Health <= 0)
        {
            enemyStateMachine.ChangeState(enemyStateMachine.EnemyDeathState);
        }
    }
}