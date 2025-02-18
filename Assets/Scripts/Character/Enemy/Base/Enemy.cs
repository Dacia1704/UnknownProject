using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Enemy : Character,IPoolingObject {
    
    [field: SerializeField] public EnemyPropertiesSO EnemyPropertiesSO { get; protected set; }
    [field: SerializeField]public PoolingObjectPropsSO PoolingObjectPropsSO { get; set; }
    protected EnemyStateMachine enemyStateMachine;
    public EnemyAnimationManager EnemyAnimationManager { get; protected set; }
    public BodyColliderManager BodyColliderManager { get; private set; }
    public EnemyAI EnemyAI { get; protected set; }
    
    public Player Player{ get; protected set; }
    
    [field: SerializeField]public EnemyStats EnemyStats { get; protected set; }

    public Attackable Attackable{ get; protected set; }

    public float YPosReset { get; private set; }
    
    
    protected override void Awake() {
        base.Awake();
        enemyStateMachine = new(this);
        Rigidbody= GetComponent<Rigidbody>();
        Attackable = GetComponentInChildren<Attackable>();
        EnemyAI = GetComponentInChildren<EnemyAI>();
        EnemyAnimationManager = GetComponentInChildren<EnemyAnimationManager>();
        BodyColliderManager = GetComponentInChildren<BodyColliderManager>();
        healthBarUI = GetComponentInChildren<HealthBarUI>();
        Player = GameManager.instance.Player;
        YPosReset = transform.position.y;
    }

    protected  void Start() {
        Damable.SetDamableLayer(EnemyPropertiesSO.DamableLayers);
        Damable.DamableStats = new EnemyStats(EnemyPropertiesSO.BaseStats);
        Attackable.SetAttackStats(EnemyPropertiesSO.BaseStats);
        OnMaxHealthChanged?.Invoke(EnemyPropertiesSO.BaseStats.Health);
        SetUpState();
    }

    private void OnEnable()
    {
        ResetCharacter();
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
        StartCoroutine(ReturnToPool());
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
        transform.position = new Vector3(transform.position.x, YPosReset, transform.position.z);
    }

    private IEnumerator ReturnToPool()
    {
        yield return new WaitForSeconds(5f);
        SetUpState();
        GameManager.instance.EnemyManager.EnemyPooling.ReturnEnemyToPool(this.gameObject);
    }

    
}