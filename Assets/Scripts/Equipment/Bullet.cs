using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour,IPoolingObject
{
        [field: SerializeField]public PoolingObjectPropsSO PoolingObjectPropsSO { get; set; }
        public Attackable Attackable {get; private set; }
        
        private void Awake()
        {
                this.Attackable = GetComponentInChildren<Attackable>();
                
        }

        private void OnEnable()
        {
            StartCoroutine(DisappearCoroutine());
        }

        private IEnumerator DisappearCoroutine()
        {
                yield return new WaitUntil(() => (Attackable.IsAttackSuccess || Attackable.IsMapCollider));
                yield return new WaitForSeconds(((BulletPropsSO)PoolingObjectPropsSO).TimeRemainAfterHit);
                Debug.Log("Disappear");
                Attackable.IsAttackSuccess = false;
                Attackable.IsMapCollider = false;
                EquipmentManager.instance.EquipmentPooling.ReleaseBulletEquipment(this.gameObject);
        }
        
        

}