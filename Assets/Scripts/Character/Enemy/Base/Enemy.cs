using System;
using System.Collections;
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
        healthBarUI = GetComponentInChildren<HealthBarUI>();
        
        SetUpState();
        
        healthBarUI.Show();
        enemyStateMachine.Enemy.Damable.transform.gameObject.SetActive(true);
        enemyStateMachine.Enemy.Attackable.transform.gameObject.SetActive(true);
        
        Damable.SetDamableLayer(EnemyPropertiesSO.DamableLayers);
        EnemyStats = new EnemyStats(EnemyPropertiesSO.BaseStats);
        Damable.DamableStats = new EnemyStats(EnemyStats);
        Attackable.SetAttackStats(EnemyStats);
        
        OnMaxHealthChanged?.Invoke(EnemyPropertiesSO.BaseStats.Health);
        OnHealthDamaged?.Invoke(EnemyStats.Health);
        healthBarUI.SetUpEaseHealthSlider(EnemyStats.Health);
        healthBarUI.SetUpHealHealthSlider(EnemyStats.Health);
        
        // StartCoroutine(HealByTime());
    }

    // private IEnumerator HealByTime()
    // {
    //     while (true)
    //     {
    //         yield return new WaitForSeconds(2f);
    //         Heal(50);
    //     }
    // }

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
    
    public void Heal(int healAmount)
    {
        EnemyStats.Health = Mathf.Clamp(EnemyStats.Health + healAmount, 0, EnemyPropertiesSO.BaseStats.Health);
        OnHealthHealed?.Invoke(EnemyStats.Health);
    }

    public override void Death()
    {
        base.Death();
        healthBarUI.Hide();
        Damable.transform.gameObject.SetActive(false);
        Attackable.transform.gameObject.SetActive(false);
    }

    public override void ResetCharacter()
    {
        base.ResetCharacter();
        healthBarUI.Show();
        Damable.transform.gameObject.SetActive(true);
        Attackable.transform.gameObject.SetActive(true);
    }
}