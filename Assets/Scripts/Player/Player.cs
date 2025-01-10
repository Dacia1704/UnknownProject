using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [HideInInspector]public Rigidbody playerRigidbody;
    
    public PlayerPropertiesSO PlayerPropertiesSO;
    private PlayerStateMachine _playerStateMachine;
    public PlayerInputSystem PlayerInputSystem = new();
    [HideInInspector] public PlayerCollisionSystem PlayerCollisionSystem;
    [HideInInspector] public PlayerAnimationController PlayerAnimationController;

    [Header("Weapon")] 
    [HideInInspector] public WeaponManager WeaponManager;
    [field: SerializeField]public Transform WeaponLeftTransform { get; private set; }
    [field: SerializeField]public Transform WeaponRightTransform { get; private set; }


    [Header("Test")] 
    public WeaponPropsSO IronWordSO;
    public WeaponPropsSO GreenStaffSO;
    public WeaponPropsSO WoodBowSO;
    private void Awake() {
        _playerStateMachine = new(this);
    }
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        PlayerAnimationController = GetComponentInChildren<PlayerAnimationController>();
        PlayerCollisionSystem = GetComponentInChildren<PlayerCollisionSystem>();
        WeaponManager = GetComponentInChildren<WeaponManager>();

        PlayerInputSystem.Start();

        _playerStateMachine.ChangeState(_playerStateMachine.PlayerIdleState);
        
        UIManager.Instance.OnSwordButtonClicked += () =>
        {
            WeaponManager.EquipWeapon(IronWordSO);
        };
        UIManager.Instance.OnStaffButtonClicked += () =>
        {
            WeaponManager.EquipWeapon(GreenStaffSO);
        };
        UIManager.Instance.OnBowButtonClicked += () =>
        {
            WeaponManager.EquipWeapon(WoodBowSO);
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
        PlayerReusableData.IsGround = PlayerCollisionSystem.isGround;
    }
    
    
    
}
