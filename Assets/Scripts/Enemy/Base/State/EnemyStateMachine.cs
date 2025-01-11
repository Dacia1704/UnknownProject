public class EnemyStateMachine: StateMachine {
    public Enemy Enemy { get; private set; }

    public EnemyIdleState EnemyIdleState { get; private set; }
    public EnemyMoveState EnemyMoveState { get; private set; }
    public EnemyAttackState EnemyAttackState { get; private set; }

    public EnemyStateMachine(Enemy enemy) {
        this.Enemy = enemy;
        EnemyIdleState = new(this);
        EnemyMoveState = new(this);
        EnemyAttackState = new(this);
    }
}