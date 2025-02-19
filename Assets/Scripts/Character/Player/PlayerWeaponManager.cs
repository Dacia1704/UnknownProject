
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerWeaponManager: MonoBehaviour
{
    protected EquipmentPooling equipmentPooling;
    protected GameObject currentRightWeapon { get; private set; }
    protected GameObject currentLeftWeapon { get; private set; }

    protected Player player;


    private void Awake()
    {
        
        player = GetComponentInParent<Player>();

    }

    private void Start()
    {
        equipmentPooling = EquipmentManager.instance.EquipmentPooling;
    }

    private void Update()
    {
        UpdateWeaponState();
    }

    public void AttackRightWeapon()
    {
        currentRightWeapon.GetComponent<Equipment>().Attack(player.transform.forward);
    }

    public void AttackLeftWeapon()
    {
        currentLeftWeapon.GetComponent<Equipment>().Attack(player.transform.forward);
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
