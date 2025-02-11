using System;
using UnityEngine;

public abstract class Enemy : Character {
    
    [field: SerializeField] public EnemyPropertiesSO EnemyPropertiesSO { get; protected set; }
    protected EnemyStateMachine enemyStateMachine;
    public EnemyAnimationController EnemyAnimationController { get; protected set; }
    public EnemyCollisionManager EnemyCollisionManager { get; protected set; }
    public EnemyAI EnemyAI { get; protected set; }
    
    public Player Player{ get; protected set; }
    
    public EnemyStats EnemyStats { get; protected set; }

    public Attackable Attackable{ get; protected set; }
    
    protected virtual void Awake() {
        enemyStateMachine = new(this);
    }

    protected override void Start() {
        base.Start();
        Player = GameManager.instance.Player;
        Rigidbody= GetComponent<Rigidbody>();
        Attackable = GetComponentInChildren<Attackable>();
        EnemyAI = GetComponentInChildren<EnemyAI>();
        EnemyAnimationController = GetComponentInChildren<EnemyAnimationController>();
        EnemyCollisionManager = GetComponentInChildren<EnemyCollisionManager>();
        
        SetUpState();
        
        enemyStateMachine.Enemy.Damable.transform.gameObject.SetActive(true);
        enemyStateMachine.Enemy.Attackable.transform.gameObject.SetActive(true);
        Damable.SetDamableLayer(EnemyPropertiesSO.DamableLayers);
        EnemyStats = new EnemyStats(EnemyPropertiesSO.BaseStats);
        Damable.DamableStats = new EnemyStats(EnemyStats);
        Attackable.SetAttackStats(EnemyStats);
        
        OnHealthChanged?.Invoke(EnemyPropertiesSO.BaseStats.Health,EnemyStats.Health);
        healthBarUI.SetUpEaseHealthSlider(EnemyStats.Health);
    }

    protected virtual void Update() {
        enemyStateMachine.Update();
    }

    protected virtual void FixedUpdate() {
        enemyStateMachine.PhysicsUpdate();
    }

    protected virtual void SetUpState()
    {
        enemyStateMachine.ChangeState(enemyStateMachine.EnemyIdleState);
    }
    
    
    
    
}