using System;
using UnityEngine;

[Serializable]
public class EquipmentData
{
    public EquipmentData(EquipmentPropsSO equipmentPropsSo, EquipmentStats equipmentStats)
    {
        EquipmentPropsSO = equipmentPropsSo;
        EquipmentStats = equipmentStats;
    }

    [field: SerializeField]public EquipmentPropsSO EquipmentPropsSO { get; set; }
    [field: SerializeField] public EquipmentStats EquipmentStats { get; set; }

    public override string ToString()
    {
        return EquipmentPropsSO.EquimentType.ToString() + " " + EquipmentPropsSO.WeaponType.ToString() + " " +EquipmentPropsSO.EquipmentSet.ToString() + " "+ EquipmentStats;
    }
}