using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "EquipmentPropsSO", menuName = "EquipmentPropsSO", order = 0)]
public class EquipmentPropsSO : PoolingObjectPropsSO,IInventoryItem
{
    [field: SerializeField] public EquimentType EquimentType { get; private set; }
    [field: SerializeField] public WeaponType WeaponType{ get; private set; }
    [field: SerializeField] public EquipmentSet EquipmentSet{ get; private set; }
    [field: SerializeField] public Sprite SpriteItem { get; set; }
}

