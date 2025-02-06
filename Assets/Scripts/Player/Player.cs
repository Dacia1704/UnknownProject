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
    
    [Header("Weapon")] 
    [HideInInspector] public PlayerEquipmentManager playerEquipmentManager;
    [field: SerializeField]public Transform WeaponLeftTransform { get; private set; }
    [field: SerializeField]public Transform WeaponRightTransform { get; private set; }

    [Header("Battle System")]
    [HideInInspector] public Damable Damable;
    public PlayerStats PlayerStats;

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
        playerEquipmentManager = GetComponentInChildren<PlayerEquipmentManager>();
        Damable = GetComponentInChildren<Damable>();

        Damable.SetTagCanDealDamList(PlayerPropertiesSO.TagCanDealDamList);

        PlayerInputSystem.Start();

        PlayerStats = new PlayerStats(PlayerPropertiesSO.BaseStats);
        UIManager.Instance.EquipmentMenuUI.SetBasePlayerStats(PlayerPropertiesSO.BaseStats);

        _playerStateMachine.ChangeState(_playerStateMachine.PlayerIdleState);
        PlayerReusableData.CurrentPlayerStats = PlayerPropertiesSO.BaseStats;

        playerEquipmentManager.EquipRightWeapon(FighterSO);
        playerEquipmentManager.EquipLeftWeapon(FighterSO);
        UIManager.Instance.OnSwordButtonClicked += () =>
        {
            playerEquipmentManager.EquipRightWeapon(IronWordSO);
            
        };
        UIManager.Instance.OnStaffButtonClicked += () =>
        {
            playerEquipmentManager.EquipRightWeapon(GreenStaffSO);
        };
        UIManager.Instance.OnBowButtonClicked += () =>
        {
            playerEquipmentManager.EquipRightWeapon(WoodBowSO);
        };

        PlayerReusableData.IsNomalAttacking = false;

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
    
    
    
}
