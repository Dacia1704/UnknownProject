using System;
using UnityEngine;

public class HitEffect: MonoBehaviour,IPoolingObject
{
        [field: SerializeField]public PoolingObjectPropsSO PoolingObjectPropsSO { get; set; }
        private ParticleSystem particle;

        private void Awake()
        {
                particle = GetComponent<ParticleSystem>();
        }

        private void OnEnable()
        {
                particle.Play();
        }

        private void LateUpdate()
        {
                if (!particle.isPlaying)
                {
                        EquipmentManager.Instance.EquipmentPooling.ReleaseHitEffectEquipment(this.gameObject);
                }
        }

}