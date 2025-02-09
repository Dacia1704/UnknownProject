using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    
    [field: SerializeField] public virtual EnemyPropertiesSO EnemyPropertiesSO { get; protected set; }
    protected EnemyStateMachine enemyStateMachine;
    public EnemyAnimationController EnemyAnimationController { get; private set; }
    public EnemyCollisionManager EnemyCollisionManager { get; private set; }
    [HideInInspector] public Rigidbody Rigidbody {get; private set;}

    public Player Player{ get; private set; }
    
    public EnemyStats EnemyStats { get; private set; }

    public Attackable Attackable{ get; private set; }
    public Damable Damable{ get; private set; }
    
    public EnemyAI EnemyAI { get; private set; }

    protected virtual void Awake() {
        enemyStateMachine = new(this);
    }

    protected virtual void Start() {
        Player = GameManager.instance.Player;
        
        Rigidbody= GetComponent<Rigidbody>();
        Attackable = GetComponentInChildren<Attackable>();
        Damable = GetComponentInChildren<Damable>();
        EnemyAI = GetComponent<EnemyAI>();
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