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
    public PlayerInputSystem PlayerInputSystem = new();
    [HideInInspector] public PlayerAnimationManager playerAnimationManager;
    [Header("Weapon")] 
    [HideInInspector] public PlayerWeaponManager playerWeaponManager;
    [field: SerializeField]public Transform WeaponLeftTransform { get; private set; }
    [field: SerializeField]public Transform WeaponRightTransform { get; private set; }

    [field: SerializeField] public PlayerStats PlayerStats{ get; private set; }
    [field: SerializeField]public PlayerStats BasePlayerStats { get; private set; }

    [Header("Test")] 
    public EquipmentPropsSO IronWordSO;
    public EquipmentPropsSO GreenStaffSO;
    public EquipmentPropsSO WoodBowSO;
    public EquipmentPropsSO FighterSO;

    [HideInInspector]public bool IsNomalAttacking;
    protected override  void Awake() {
        base.Awake();
        playerStateMachine = new(this);
        Rigidbody = GetComponent<Rigidbody>();
        playerAnimationManager = GetComponentInChildren<PlayerAnimationManager>();
        playerWeaponManager = GetComponentInChildren<PlayerWeaponManager>();
        healthBarUI = UIManager.Instance.PlayerHealthBarUI;
    }
    protected void Start()
    {
        PlayerInputSystem.Start();
        //set up stats
        BasePlayerStats = new PlayerStats(PlayerPropertiesSO.BaseStats);
        PlayerStats = new PlayerStats(PlayerPropertiesSO.BaseStats);
        
        Damable.SetDamableLayer(PlayerPropertiesSO.DamableLayers);
        Damable.DamableStats = new PlayerStats(BasePlayerStats);
        
        OnMaxHealthChanged?.Invoke(PlayerPropertiesSO.BaseStats.Health);
        OnHealthDamaged?.Invoke(PlayerPropertiesSO.BaseStats.Health);
        healthBarUI.SetUpEaseHealthSlider(PlayerStats.Health);
        healthBarUI.SetUpHealHealthSlider(PlayerStats.Health);
        UIManager.Instance.EquipmentMenuUI.SetBasePlayerStats(PlayerPropertiesSO.BaseStats);

        //setup state
        playerStateMachine.ChangeState(playerStateMachine.PlayerIdleState);
        IsNomalAttacking = false;

        //setup equipment
        playerWeaponManager.EquipRightWeapon(FighterSO);
        playerWeaponManager.EquipLeftWeapon(FighterSO);
        
        //test
        UIManager.Instance.OnSwordButtonClicked += () =>
        {
            playerWeaponManager.EquipRightWeapon(IronWordSO);
            
        };
        UIManager.Instance.OnStaffButtonClicked += () =>
        {
            playerWeaponManager.EquipRightWeapon(GreenStaffSO);
        };
        UIManager.Instance.OnBowButtonClicked += () =>
        {
            playerWeaponManager.EquipRightWeapon(WoodBowSO);
        };

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
    private void Update()
    {
        PlayerInputSystem.Update();
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
