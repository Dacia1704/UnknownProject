using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventoryItemUI: DraggableItem
{
    [FormerlySerializedAs("poolingEquipmentPropsSo")] [FormerlySerializedAs("PoolingWeaponPropsSO")] public EquipmentPropsSO equipmentPropsSo;

    protected override void OnEnable()
    {
        base.OnEnable();
        if (equipmentPropsSo)
        {
            Debug.Log("set up sprite");
            IconImage.sprite = equipmentPropsSo.SpriteItem;
        }
    }
    
    
    
    
}