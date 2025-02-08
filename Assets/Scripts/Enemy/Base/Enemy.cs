using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    [field: SerializeField] public EnemyPropertiesSO EnemyPropertiesSO { get; private set; }
    [HideInInspector] public Rigidbody Rigidbody {get; private set;}

    protected EnemyStateMachine enemyStateMachine;

    public EnemyAnimationController EnemyAnimationController { get; private set; }
    public EnemyCollisionSystem EnemyCollisionSystem { get; private set; }

    public Player Player{ get; private set; }
    
    public EnemyStats EnemyStats { get; private set; }

    public Attackable Attackable{ get; private set; }
    public Damable Damable{ get; private set; }

    protected virtual void Awake() {
        enemyStateMachine = new(this);
    }

    protected virtual void Start() {
        Player = FindAnyObjectByType<Player>();
        Rigidbody= GetComponent<Rigidbody>();
        Attackable = GetComponentInChildren<Attackable>();
        Damable = GetComponentInChildren<Damable>();
        EnemyAnimationController = GetComponentInChildren<EnemyAnimationController>();
        EnemyCollisionSystem = GetComponentInChildren<EnemyCollisionSystem>();
        enemyStateMachine.ChangeState(enemyStateMachine.EnemyIdleState);
        
        Damable.SetDamableLayer(EnemyPropertiesSO.DamableLayers);

        EnemyStats = new EnemyStats(EnemyPropertiesSO.BaseStats);
        Damable.BaseDamableStats = new EnemyStats(EnemyStats);
    }

    protected virtual void Update() {
        enemyStateMachine.Update();
    }

    protected virtual void FixedUpdate() {
        enemyStateMachine.PhysicsUpdate();
    }
    
    
}