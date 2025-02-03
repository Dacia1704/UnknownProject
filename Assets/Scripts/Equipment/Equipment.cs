using System;
using UnityEngine;


[RequireComponent(typeof(Collider))]
 public class Equipment :MonoBehaviour, IPoolingObject
 {
    [field: SerializeField] public EquipmentPropsSO EquipmentPropsSO { get; set; }
    [field: SerializeField] public EquipmentStats EquipmentStats { get; set; }
    PoolingObjectPropsSO IPoolingObject.PoolingObjectPropsSO 
    {
        get => EquipmentPropsSO; 
        set => EquipmentPropsSO = (EquipmentPropsSO)value;
    }
     private void OnMouseDown()
     {
         EquipmentManager.instance.CollectEquipment(this.gameObject);
     }
 }