using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI: DraggableItem
{
    public WeaponPropsSO weaponPropsSO;

    protected override void OnEnable()
    {
        base.OnEnable();
        if (weaponPropsSO)
        {
            Debug.Log("set up sprite");
            IconImage.sprite = weaponPropsSO.IconSprite;
        }
    }
    
    
    
    
}