using UnityEngine;

public abstract class EnemyState : IState
{
    protected EnemyStateMachine enemyStateMachine;
    public EnemyState(EnemyStateMachine enemyStateMachine) {
        this.enemyStateMachine = enemyStateMachine;
    }
    public virtual void Enter()
    {
        // Debug.Log("State: " + GetType().Name);
    }

    public virtual void Exit()
    {
    }

    public virtual void PhysicsUpdate()
    {
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
        if(enemyStateMachine.Enemy.Rigidbody.velocity.x < -0.1f || enemyStateMachine.Enemy.Rigidbody.velocity.x > 0.1f ||
        enemyStateMachine.Enemy.Rigidbody.velocity.z < -0.1f || enemyStateMachine.Enemy.Rigidbody.velocity.z > 0.1f ) {
            enemyStateMachine.ChangeState(enemyStateMachine.EnemyMoveState);
        }
    }
}