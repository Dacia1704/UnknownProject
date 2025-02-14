﻿
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerWeaponManager: MonoBehaviour
{
    protected EquipmentPooling equipmentPooling;
    [field: SerializeField]protected GameObject currentRightWeapon { get; private set; }
    [field: SerializeField]protected GameObject currentLeftWeapon { get; private set; }

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
            player.PlayerAnimationController.SetFloatValueAnimation("equiped",1f);
            EquipmentPropsSO equipmentSo = currentRightWeapon.GetComponent<Equipment>().EquipmentPropsSO;
            if (equipmentSo.WeaponType == WeaponType.Sword)
            {
                player.PlayerAnimationController.SetBoolValueAnimation("sword",true);
                player.PlayerAnimationController.SetBoolValueAnimation("staff",false);
                player.PlayerAnimationController.SetBoolValueAnimation("bow",false);
            }
            else if(equipmentSo.WeaponType == WeaponType.Staff)
            {
                player.PlayerAnimationController.SetBoolValueAnimation("sword",false);
                player.PlayerAnimationController.SetBoolValueAnimation("staff",true);
                player.PlayerAnimationController.SetBoolValueAnimation("bow",false);
            } else if (equipmentSo.WeaponType == WeaponType.Bow)
            {
                player.PlayerAnimationController.SetBoolValueAnimation("sword",false);
                player.PlayerAnimationController.SetBoolValueAnimation("staff",false);
                player.PlayerAnimationController.SetBoolValueAnimation("bow",true);
            } else {
                player.PlayerAnimationController.SetFloatValueAnimation("equiped",0f);
            }
        }
        else
        {
            player.PlayerAnimationController.SetFloatValueAnimation("equiped",0f);
        }
    }
}
