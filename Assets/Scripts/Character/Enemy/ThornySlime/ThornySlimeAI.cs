using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ThornySlimeAI:EnemyAI
{
        private ThornySlime thornySlime => (ThornySlime)enemy;
        [field: SerializeField] public bool ShouldDefend { get;  set; }

        private SphereCollider sphereCollider;

        private float defendCounter;

        protected override void Awake()
        {
                base.Awake();
                sphereCollider = gameObject.AddComponent<SphereCollider>();
                sphereCollider.isTrigger = true;
                sphereCollider.radius = thornySlime.ThornySlimePropertiesSO.DefendDetectDistance;

                defendCounter = 0;
        }

        protected override void FixedUpdate()
        {
                base.FixedUpdate();
                if (defendCounter > 0)
                {
                        defendCounter -= Time.fixedDeltaTime;
                }
        }


        private void OnTriggerEnter(Collider other)
        {
                if ((enemy.EnemyPropertiesSO.DamableLayers & (1 << other.gameObject.layer)) != 0 && defendCounter <=0)
                {
                        ShouldDefend = true;
                }
        }

        private void OnTriggerExit(Collider other)
        {
                if ((enemy.EnemyPropertiesSO.DamableLayers & (1 << other.gameObject.layer)) != 0 && defendCounter <=0)
                {
                        ShouldDefend = false;
                }
        }

        public void ResetDefendCounter()
        {
                defendCounter = thornySlime.ThornySlimePropertiesSO.DefendCoolDown;
        }
}