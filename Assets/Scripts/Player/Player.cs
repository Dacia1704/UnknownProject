using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [HideInInspector]public Rigidbody PlayerRigidbody;
    
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

    [Header("Battle System")]
    [HideInInspector] public Damable Damable;
    public PlayerStats PlayerStats { get; private set; }

    [Header("Test")] 
    public EquipmentPropsSO IronWordSO;
    public EquipmentPropsSO GreenStaffSO;
    public EquipmentPropsSO WoodBowSO;
    public EquipmentPropsSO FighterSO;
    private void Awake() {
        _playerStateMachine = new(this);
    }
    private void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        PlayerAnimationController = GetComponentInChildren<PlayerAnimationController>();
        PlayerBodyCollisionManager = GetComponentInChildren<PlayerBodyCollisionManager>();
        playerWeaponManager = GetComponentInChildren<PlayerWeaponManager>();
        Damable = GetComponentInChildren<Damable>();

        Damable.SetDamableLayer(PlayerPropertiesSO.DamableLayers);

        PlayerInputSystem.Start();
        
        //set up stats
        PlayerReusableData.CurrentPlayerStats = PlayerPropertiesSO.BaseStats;
        SetPlayerStats(PlayerPropertiesSO.BaseStats);
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


    }

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
        PlayerStats = new PlayerStats(playerStats);
    }
    
    
    
}
