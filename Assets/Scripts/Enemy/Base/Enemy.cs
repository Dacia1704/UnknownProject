using UnityEngine;

public abstract class Enemy : MonoBehaviour,IAttackable,IDamable {
    [field: SerializeField] public EnemyPropertiesSO EnemyPropertiesSO { get; private set; }
    [HideInInspector] public Rigidbody Rigidbody {get; private set;}

    protected EnemyStateMachine enemyStateMachine;

    public EnemyAnimationController EnemyAnimationController { get; private set; }
    public EnemyCollisionSystem EnemyCollisionSystem { get; private set; }

    public Player Player{ get; private set; }

    public float Attack { get ;set; }
    public int MaxHealth { get ;set; }

    protected virtual void Awake() {
        enemyStateMachine = new(this);
    }

    protected virtual void Start() {
        Player = FindAnyObjectByType<Player>();
        Rigidbody= GetComponent<Rigidbody>();
        EnemyAnimationController = GetComponentInChildren<EnemyAnimationController>();
        EnemyCollisionSystem = GetComponentInChildren<EnemyCollisionSystem>();
        MaxHealth = EnemyPropertiesSO.BaseHealth;
        enemyStateMachine.ChangeState(enemyStateMachine.EnemyIdleState);
    }

    protected virtual void Update() {
        enemyStateMachine.Update();
    }

    protected virtual void FixedUpdate() {
        enemyStateMachine.PhysicsUpdate();
    }
}