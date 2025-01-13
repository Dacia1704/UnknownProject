
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class WeaponManager: MonoBehaviour
{
    protected WeaponObjectPooling weaponObjectPooling;
    protected GameObject currentRightWeapon { get; private set; }
    protected GameObject currentLeftWeapon { get; private set; }

    protected Player player;


    private void Awake()
    {
        weaponObjectPooling = GetComponent<WeaponObjectPooling>();
        player = GetComponentInParent<Player>();

    }

    private void Update()
    {
        UpdateEquipmentState();
    }

    public void EquipRightWeapon(WeaponPropsSO weapon)
    {
        if(currentRightWeapon)
            weaponObjectPooling.ReleaseObject(currentRightWeapon);
        GameObject poolingWeapon = weaponObjectPooling.GetObject(weapon.KeyObject);
        currentRightWeapon = poolingWeapon;
        poolingWeapon.transform.SetParent(player.WeaponRightTransform);
        poolingWeapon.transform.localPosition = Vector3.zero;
        poolingWeapon.transform.localRotation = Quaternion.identity;
    }
    public void EquipLeftWeapon(WeaponPropsSO weapon)
    {
        if(currentLeftWeapon)
            weaponObjectPooling.ReleaseObject(currentLeftWeapon);
        GameObject poolingWeapon = weaponObjectPooling.GetObject(weapon.KeyObject);
        currentRightWeapon = poolingWeapon;
        poolingWeapon.transform.SetParent(player.WeaponLeftTransform);
        poolingWeapon.transform.localPosition = Vector3.zero;
        poolingWeapon.transform.localRotation = Quaternion.identity;
    }

    public void UpdateEquipmentState()
    {
        if (currentRightWeapon)
        {
            player.PlayerAnimationController.SetFloatValueAnimation("equiped",1f);
            WeaponPropsSO weaponSO = currentRightWeapon.GetComponent<Weapon>().ObjectPropsSO as WeaponPropsSO;
            if (weaponSO.Type == WeaponType.Sword)
            {
                player.PlayerAnimationController.SetBoolValueAnimation("sword",true);
                player.PlayerAnimationController.SetBoolValueAnimation("staff",false);
                player.PlayerAnimationController.SetBoolValueAnimation("bow",false);
            }
            else if(weaponSO.Type == WeaponType.Staff)
            {
                player.PlayerAnimationController.SetBoolValueAnimation("sword",false);
                player.PlayerAnimationController.SetBoolValueAnimation("staff",true);
                player.PlayerAnimationController.SetBoolValueAnimation("bow",false);
            } else if (weaponSO.Type == WeaponType.Bow)
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
