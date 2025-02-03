using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PoolingEquipmentPropsSO", menuName = "PoolingEquipmentPropsSO", order = 0)]
public class PoolingEquipmentPropsSO : PoolingObjectPropsSO,IInventoryItem
{
    [field: SerializeField] public EquimentType EquimentType { get; private set; }
    [field: SerializeField] public WeaponType WeaponType{ get; private set; }
    [field: SerializeField] public EquipmentSet EquipmentSet{ get; private set; }
    [field: SerializeField] public EquipmentStats EquipmentStats { get; set; }
    
    [field: SerializeField] public Sprite SpriteItem { get; set; }
}

