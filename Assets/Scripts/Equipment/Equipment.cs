using System;
using UnityEngine;


[RequireComponent(typeof(Collider))]
 public class Equipment :MonoBehaviour, IPoolingObject
 {
    [field: SerializeField] public EquipmentPropsSO EquipmentPropsSO { get; set; }
    public EquipmentStats EquipmentStats { get; set; }
    [field: SerializeField] private Transform attackTransform;
    PoolingObjectPropsSO IPoolingObject.PoolingObjectPropsSO 
    {
        get => EquipmentPropsSO; 
        set => EquipmentPropsSO = (EquipmentPropsSO)value;
    }
     private void OnMouseDown()
     {
         EquipmentManager.instance.CollectEquipment(this.gameObject);
     }

     public void Attack(Vector3 direction)
     {
         GameObject bullet = EquipmentManager.instance.EquipmentPooling.GetBulletEquipment(EquipmentPropsSO.EquipmentSet,
             EquipmentPropsSO.EquimentType, EquipmentPropsSO.WeaponType);
         
         //set up transform
         bullet.transform.position = attackTransform.position;
         bullet.transform.LookAt(new Vector3(bullet.transform.position.x + direction.x, bullet.transform.position.y,bullet.transform.position.z + direction.z));
         
         //setup stats
         bullet.GetComponent<Bullet>().Attackable.SetAttackStats(transform.root.GetComponent<Player>().PlayerStats);
         
         bullet.GetComponent<Rigidbody>().velocity = new Vector3(direction.x *20, 0, direction.z *20);
     }
     
     
 }