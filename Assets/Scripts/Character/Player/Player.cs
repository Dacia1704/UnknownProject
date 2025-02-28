using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder;
using UnityEngine.Serialization;

public class Player : Character
{
    
    
    public PlayerPropertiesSO PlayerPropertiesSO;
    private PlayerStateMachine playerStateMachine;
    public PlayerInputManager PlayerInputManager = new();
    [HideInInspector] public AudioSource PlayerAudioSource;
    [HideInInspector] public PlayerAnimationManager playerAnimationManager;
    [Header("Weapon")] 
    [HideInInspector] public PlayerWeaponManager playerWeaponManager;
    [field: SerializeField]public Transform WeaponLeftTransform { get; private set; }
    [field: SerializeField]public Transform WeaponRightTransform { get; private set; }

    [field: SerializeField] public PlayerStats PlayerStats{ get; private set; }
    [field: SerializeField]public PlayerStats BasePlayerStats { get; private set; }

    

    [HideInInspector]public bool IsNomalAttacking;
    protected override  void Awake() {
        base.Awake();
        playerStateMachine = new(this);
        Rigidbody = GetComponent<Rigidbody>();
        playerAnimationManager = GetComponentInChildren<PlayerAnimationManager>();
        playerWeaponManager = GetComponentInChildren<PlayerWeaponManager>();
        PlayerAudioSource = GetComponent<AudioSource>();
    }
    protected void Start()
    {
        PlayerInputManager.Start();
        healthBarUI = GameSceneUIManager.Instance.PlayerHealthBarUI;
        //set up stats
        BasePlayerStats = new PlayerStats(PlayerPropertiesSO.BaseStats);
        PlayerStats = new PlayerStats(PlayerPropertiesSO.BaseStats);
        
        Damable.SetDamableLayer(PlayerPropertiesSO.DamableLayers);
        Damable.DamableStats = new PlayerStats(BasePlayerStats);
        
        OnMaxHealthChanged?.Invoke(PlayerPropertiesSO.BaseStats.Health);
        OnHealthDamaged?.Invoke(PlayerPropertiesSO.BaseStats.Health);
        healthBarUI.SetUpEaseHealthSlider(PlayerStats.Health);
        healthBarUI.SetUpHealHealthSlider(PlayerStats.Health);
        GameSceneUIManager.Instance.EquipmentMenuUI.SetBasePlayerStats(PlayerPropertiesSO.BaseStats);

        //setup state
        playerStateMachine.ChangeState(playerStateMachine.PlayerIdleState);
        IsNomalAttacking = false;
        
    }
    private void Update()
    {
        PlayerInputManager.Update();
        playerStateMachine.Update();
    }
    private void FixedUpdate() {
        playerStateMachine.PhysicsUpdate();
        
    }

    public void SetPlayerStats(PlayerStats playerStats)
    {
        BasePlayerStats = new PlayerStats(playerStats);
        PlayerStats = new PlayerStats(playerStats,playerStats.Health);
        OnMaxHealthChanged?.Invoke(BasePlayerStats.Health);
        OnHealthDamaged?.Invoke(BasePlayerStats.Health);
    }

    public void Heal(int healAmount)
    {
        PlayerStats.Health  = Math.Clamp(PlayerStats.Health + healAmount, 0, BasePlayerStats.Health);
    }
    
    
    
}
