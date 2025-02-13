using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder;
using UnityEngine.Serialization;

public class Player : Character
{
    
    
    public PlayerPropertiesSO PlayerPropertiesSO;
    private PlayerStateMachine _playerStateMachine;
    public PlayerInputSystem PlayerInputSystem = new();
    [HideInInspector] public PlayerBodyCollisionManager PlayerBodyCollisionManager;
    [HideInInspector] public PlayerAnimationController PlayerAnimationController;
    
    [FormerlySerializedAs("playerEquipmentManager")]
    [Header("Weapon")] 
    [HideInInspector] public PlayerWeaponManager playerWeaponManager;
    [field: SerializeField]public Transform WeaponLeftTransform { get; private set; }
    [field: SerializeField]public Transform WeaponRightTransform { get; private set; }
    
    [field: SerializeField]public PlayerStats PlayerStats { get; private set; }
    [field: SerializeField]public PlayerStats BasePlayerStats { get; private set; }

    [Header("Test")] 
    public EquipmentPropsSO IronWordSO;
    public EquipmentPropsSO GreenStaffSO;
    public EquipmentPropsSO WoodBowSO;
    public EquipmentPropsSO FighterSO;
    private void Awake() {
        _playerStateMachine = new(this);
    }
    protected override void Start()
    {
        base.Start();
        Rigidbody = GetComponent<Rigidbody>();
        PlayerAnimationController = GetComponentInChildren<PlayerAnimationController>();
        PlayerBodyCollisionManager = GetComponentInChildren<PlayerBodyCollisionManager>();
        playerWeaponManager = GetComponentInChildren<PlayerWeaponManager>();

        Damable.SetDamableLayer(PlayerPropertiesSO.DamableLayers);

        PlayerInputSystem.Start();
        
        //set up stats
        healthBarUI = UIManager.Instance.PlayerHealthBarUI;
        PlayerReusableData.CurrentPlayerStats = PlayerPropertiesSO.BaseStats;
        SetPlayerStats(PlayerPropertiesSO.BaseStats);
        healthBarUI.SetUpEaseHealthSlider(PlayerStats.Health);
        healthBarUI.SetUpHealHealthSlider(PlayerStats.Health);
        UIManager.Instance.EquipmentMenuUI.SetBasePlayerStats(PlayerPropertiesSO.BaseStats);

        //setup state
        _playerStateMachine.ChangeState(_playerStateMachine.PlayerIdleState);
        PlayerReusableData.IsNomalAttacking = false;

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

    // Update is called once per frame
    private void Update()
    {
        PlayerInputSystem.Update();
        UpdateReusableData();
        _playerStateMachine.Update();
    }

    private void FixedUpdate() {
        _playerStateMachine.PhysicsUpdate();
        
    }

    public void UpdateReusableData()
    {
        PlayerReusableData.MovementInput = PlayerInputSystem.MovementInput;
        PlayerReusableData.IsGround = PlayerBodyCollisionManager.isGround;
    }

    public void SetPlayerStats(PlayerStats playerStats)
    {
        BasePlayerStats = new PlayerStats(playerStats);
        PlayerStats = new PlayerStats(playerStats,playerStats.Health);
        OnMaxHealthChanged?.Invoke(BasePlayerStats.Health);
        OnHealthDamaged?.Invoke(playerStats.Health);
    }

    public void Heal(int healAmount)
    {
        PlayerStats.Health  = Math.Clamp(PlayerStats.Health + healAmount, 0, BasePlayerStats.Health);
    }
    
    
    
}
