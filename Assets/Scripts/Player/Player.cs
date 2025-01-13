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
    [HideInInspector] public WeaponManager WeaponManager;
    [field: SerializeField]public Transform WeaponLeftTransform { get; private set; }
    [field: SerializeField]public Transform WeaponRightTransform { get; private set; }

    [Header("Battle System")]
    [HideInInspector] public Damable Damable;


    [Header("Test")] 
    public WeaponPropsSO IronWordSO;
    public WeaponPropsSO GreenStaffSO;
    public WeaponPropsSO WoodBowSO;
    public WeaponPropsSO FighterSO;
    private void Awake() {
        _playerStateMachine = new(this);
    }
    private void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        PlayerAnimationController = GetComponentInChildren<PlayerAnimationController>();
        PlayerBodyCollisionManager = GetComponentInChildren<PlayerBodyCollisionManager>();
        WeaponManager = GetComponentInChildren<WeaponManager>();
        Damable = GetComponentInChildren<Damable>();

        Damable.SetTagCanDealDamList(PlayerPropertiesSO.TagCanDealDamList);

        PlayerInputSystem.Start();

        _playerStateMachine.ChangeState(_playerStateMachine.PlayerIdleState);


        WeaponManager.EquipRightWeapon(FighterSO);
        WeaponManager.EquipLeftWeapon(FighterSO);
        UIManager.Instance.OnSwordButtonClicked += () =>
        {
            WeaponManager.EquipRightWeapon(IronWordSO);
            
        };
        UIManager.Instance.OnStaffButtonClicked += () =>
        {
            WeaponManager.EquipRightWeapon(GreenStaffSO);
        };
        UIManager.Instance.OnBowButtonClicked += () =>
        {
            WeaponManager.EquipRightWeapon(WoodBowSO);
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
