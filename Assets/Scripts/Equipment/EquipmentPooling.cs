
using UnityEngine;

public class EquipmentPooling: ObjectPooling
{
    public string GetKeyObjectEquiment(EquipmentSet set,EquimentType type,WeaponType wtype)
    {
        if (type == EquimentType.Weapon)
        {
            return set.ToString() + wtype.ToString();
        }
        return set.ToString() + type.ToString();
    }

    public GameObject GetEquipment(EquipmentSet set, EquimentType type,WeaponType wtype)
    {
        return GetObject(GetKeyObjectEquiment(set, type,wtype));
    }
    
}