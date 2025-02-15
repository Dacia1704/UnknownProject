using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Enemy : Character {
    
    [field: SerializeField] public EnemyPropertiesSO EnemyPropertiesSO { get; protected set; }
    protected EnemyStateMachine enemyStateMachine;
    public EnemyAnimationManager EnemyAnimationManager { get; protected set; }
    public BodyColliderManager BodyColliderManager { get; private set; }
    public EnemyAI EnemyAI { get; protected set; }
    
    public Player Player{ get; protected set; }
    
    [field: SerializeField]public EnemyStats EnemyStats { get; protected set; }

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
        EnemyAnimationManager = GetComponentInChildren<EnemyAnimationManager>();
        BodyColliderManager = GetComponentInChildren<BodyColliderManager>();
        healthBarUI = GetComponentInChildren<HealthBarUI>();
        
        SetUpState(); // need reset
        Damable.gameObject.SetActive(true); // need reset
        Attackable.gameObject.SetActive(true); // need reset
        EnemyStats = new EnemyStats(EnemyPropertiesSO.BaseStats); // need reset
        
        Damable.SetDamableLayer(EnemyPropertiesSO.DamableLayers);
        Damable.DamableStats = new EnemyStats(EnemyPropertiesSO.BaseStats);
        Attackable.SetAttackStats(EnemyPropertiesSO.BaseStats);
        
        OnMaxHealthChanged?.Invoke(EnemyPropertiesSO.BaseStats.Health);
        OnHealthDamaged?.Invoke(EnemyStats.Health);
        healthBarUI.SetUpEaseHealthSlider(EnemyStats.Health);
        healthBarUI.SetUpHealHealthSlider(EnemyStats.Health);
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

    public override void DeathStart()
    {
        base.DeathStart();
        Damable.transform.gameObject.SetActive(false);
        Attackable.transform.gameObject.SetActive(false);
        GameObject equipment = EquipmentManager.instance.RandomDrop();
        equipment.transform.position = transform.position;
    }
    public override void DeathEnd()
    {
        base.DeathEnd();
        BodyColliderManager.gameObject.SetActive(false);  // when body collider disable, character body will drop
    }
    public override void ResetCharacter()
    {
        base.ResetCharacter();
        Damable.transform.gameObject.SetActive(true);
        Attackable.transform.gameObject.SetActive(true);
        BodyColliderManager.gameObject.SetActive(true);
        EnemyStats = new EnemyStats(EnemyPropertiesSO.BaseStats);
        OnHealthDamaged?.Invoke(EnemyStats.Health);
        healthBarUI.SetUpEaseHealthSlider(EnemyStats.Health);
        healthBarUI.SetUpHealHealthSlider(EnemyStats.Health);
    }

    private IEnumerator ResetToPushInPool()
    {
        yield return new WaitForSeconds(5f);
        ResetCharacter();
        GameManager.instance.EnemyManager.EnemyPooling.ReturnEnemyToPool(this.gameObject);
    }
}