public class EnemyStateMachine: StateMachine {
    public Enemy Enemy { get; protected set; }

    public EnemyIdleState EnemyIdleState { get; protected set; }
    public EnemyMoveState EnemyMoveState { get; protected set; }
    public EnemyAttackState EnemyAttackState { get; protected set; }
    public EnemyHitState EnemyHitState { get; protected set; }
    public EnemyDeathState EnemyDeathState { get; protected set; }

    public EnemyStateMachine(Enemy enemy) {
        this.Enemy = enemy;
        EnemyIdleState = new(this);
        EnemyMoveState = new(this);
        EnemyAttackState = new(this);
        EnemyHitState = new (this);
        EnemyDeathState = new(this);
    }
}