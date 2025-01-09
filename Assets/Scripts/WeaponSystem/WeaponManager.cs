
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class WeaponManager: MonoBehaviour
{
    protected WeaponObjectPooling weaponObjectPooling;
    protected GameObject currentWeapon { get; private set; }

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

    public void EquipWeapon(WeaponPropsSO weapon)
    {
        if(currentWeapon)
            weaponObjectPooling.ReleaseObject(currentWeapon);
        GameObject poolingWeapon = weaponObjectPooling.GetObject(weapon.KeyObject);
        currentWeapon = poolingWeapon;
        poolingWeapon.transform.SetParent(player.WeaponRightTransform);
        poolingWeapon.transform.localPosition = Vector3.zero;
        poolingWeapon.transform.localRotation = Quaternion.identity;
    }

    public void UpdateEquipmentState()
    {
        if (currentWeapon)
        {
            player.PlayerAnimationController.SetFloatValueAnimation("equiped",1f);
            WeaponPropsSO weaponSO = currentWeapon.GetComponent<Weapon>().ObjectPropsSO as WeaponPropsSO;
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
            }
        }
        else
        {
            player.PlayerAnimationController.SetFloatValueAnimation("equiped",0f);
        }
    }
}
