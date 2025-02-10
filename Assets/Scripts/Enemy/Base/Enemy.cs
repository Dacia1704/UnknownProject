using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    
    [field: SerializeField] public EnemyPropertiesSO EnemyPropertiesSO { get; protected set; }
    protected EnemyStateMachine enemyStateMachine;
    public EnemyAnimationController EnemyAnimationController { get; protected set; }
    public EnemyCollisionManager EnemyCollisionManager { get; protected set; }
    public EnemyAI EnemyAI { get; protected set; }
    
    
    [HideInInspector] public Rigidbody Rigidbody {get; protected set;}

    
    public Player Player{ get; protected set; }
    
    public EnemyStats EnemyStats { get; protected set; }

    public Attackable Attackable{ get; protected set; }
    public Damable Damable{ get; protected set; }
    

    protected virtual void Awake() {
        enemyStateMachine = new(this);
    }

    protected virtual void Start() {
        Player = GameManager.instance.Player;
        
        Rigidbody= GetComponent<Rigidbody>();
        Attackable = GetComponentInChildren<Attackable>();
        Damable = GetComponentInChildren<Damable>();
        EnemyAI = GetComponentInChildren<EnemyAI>();
        EnemyAnimationController = GetComponentInChildren<EnemyAnimationController>();
        EnemyCollisionManager = GetComponentInChildren<EnemyCollisionManager>();
        
        enemyStateMachine.ChangeState(enemyStateMachine.EnemyIdleState);
        enemyStateMachine.Enemy.Damable.transform.gameObject.SetActive(true);
        enemyStateMachine.Enemy.Attackable.transform.gameObject.SetActive(true);
        
        Damable.SetDamableLayer(EnemyPropertiesSO.DamableLayers);

        EnemyStats = new EnemyStats(EnemyPropertiesSO.BaseStats);
        Damable.DamableStats = new EnemyStats(EnemyStats);
        Attackable.SetAttackStats(EnemyStats);
    }

    protected virtual void Update() {
        enemyStateMachine.Update();
    }

    protected virtual void FixedUpdate() {
        enemyStateMachine.PhysicsUpdate();
    }
    
    
}