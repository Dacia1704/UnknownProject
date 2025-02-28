
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class PlayerWeaponManager: MonoBehaviour
{
    protected EquipmentPooling equipmentPooling;
    protected GameObject currentRightWeapon { get; private set; }
    protected GameObject currentLeftWeapon { get; private set; }

    protected Player player;
    
    protected List<EquipmentPropsSO> weaponsList ;
    private int currentWeaponIndex = 0;
    
    [SerializeField] private EquipmentPropsSO fighterSO;


    private void Awake()
    {
        
        player = GetComponentInParent<Player>();

    }

    private void Start()
    {
        equipmentPooling = EquipmentManager.Instance.EquipmentPooling;
        weaponsList = new List<EquipmentPropsSO>();
        currentWeaponIndex = 0;
        EquipRightWeapon(fighterSO);
        EquipLeftWeapon(fighterSO);
        GameSceneUIManager.Instance.EquipmentMenuUI.OnEquipmentChanged += UpdateWeapon;
    }

    private void Update()
    {
        UpdateWeaponState();

        if (player.PlayerInputManager.SwapWeaponInput)
        {
            SwapWeapon();
            player.PlayerInputManager.SwapWeaponInput = false;
        }
    }

    public void AttackRightWeapon()
    {
        currentRightWeapon.GetComponent<Equipment>().Attack(player.transform.forward);
    }

    public void AttackLeftWeapon()
    {
        currentLeftWeapon.GetComponent<Equipment>().Attack(player.transform.forward);
    }

    public void SwapWeapon()
    {
        if (weaponsList.Count <= 1) return;
        if (currentWeaponIndex == 0)
        {
            EquipRightWeapon(weaponsList[1]);
            currentWeaponIndex = 1;
        }
        else
        {
            EquipRightWeapon(weaponsList[0]);
            currentWeaponIndex = 0;
        }
    }

    public void UpdateWeapon(List<InventoryItemUI> listEquippedItems)
    {
        weaponsList.Clear();
        foreach (InventoryItemUI item in listEquippedItems)
        {
            if(item.EquipmentData.EquipmentPropsSO == null) continue;
            if (item.EquipmentData?.EquipmentPropsSO.EquimentType == EquimentType.Weapon)
            {
                weaponsList.Add(item.EquipmentData.EquipmentPropsSO);
            }
        }

        if (weaponsList.Count > 0)
        {
            EquipRightWeapon(weaponsList[0]);
            currentWeaponIndex = 0;
        }
        else
        {
            EquipRightWeapon(fighterSO);
            EquipLeftWeapon(fighterSO);
        }
    }
    

    public void EquipRightWeapon(EquipmentPropsSO equipmentSo)
    {
        if(currentRightWeapon)
            equipmentPooling.ReleaseObject(currentRightWeapon);
        GameObject poolingWeapon = equipmentPooling.GetObject(equipmentSo.KeyObject);
        currentRightWeapon = poolingWeapon;
        poolingWeapon.transform.SetParent(player.WeaponRightTransform);
        poolingWeapon.transform.localPosition = Vector3.zero;
        poolingWeapon.transform.localRotation = Quaternion.identity;
    }
    public void EquipLeftWeapon(EquipmentPropsSO equipmentSo)
    {
        if(currentLeftWeapon)
            equipmentPooling.ReleaseObject(currentLeftWeapon);
        GameObject poolingWeapon = equipmentPooling.GetObject(equipmentSo.KeyObject);
        currentLeftWeapon = poolingWeapon;
        poolingWeapon.transform.SetParent(player.WeaponLeftTransform);
        poolingWeapon.transform.localPosition = Vector3.zero;
        poolingWeapon.transform.localRotation = Quaternion.identity;
    }

    public void UpdateWeaponState()
    {
        if (currentRightWeapon)
        {
            player.playerAnimationManager.SetFloatValueAnimation("equiped",1f);
            EquipmentPropsSO equipmentSo = currentRightWeapon.GetComponent<Equipment>().EquipmentPropsSO;
            if (equipmentSo.WeaponType == WeaponType.Sword)
            {
                player.playerAnimationManager.SetBoolValueAnimation("sword",true);
                player.playerAnimationManager.SetBoolValueAnimation("staff",false);
                player.playerAnimationManager.SetBoolValueAnimation("bow",false);
            }
            else if(equipmentSo.WeaponType == WeaponType.Staff)
            {
                player.playerAnimationManager.SetBoolValueAnimation("sword",false);
                player.playerAnimationManager.SetBoolValueAnimation("staff",true);
                player.playerAnimationManager.SetBoolValueAnimation("bow",false);
            } else if (equipmentSo.WeaponType == WeaponType.Bow)
            {
                player.playerAnimationManager.SetBoolValueAnimation("sword",false);
                player.playerAnimationManager.SetBoolValueAnimation("staff",false);
                player.playerAnimationManager.SetBoolValueAnimation("bow",true);
            } else {
                player.playerAnimationManager.SetFloatValueAnimation("equiped",0f);
            }
        }
        else
        {
            player.playerAnimationManager.SetFloatValueAnimation("equiped",0f);
        }
    }
}
