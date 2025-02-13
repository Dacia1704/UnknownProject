using System;
using UnityEngine;

public class EnemyHealthBarUI: HealthBarUI
{
        protected override void Start()
        {
                character = GetComponentInParent<Character>();
                base.Start();
        }

        private void LateUpdate()
        {
                LookAtCamera();
        }
        
        protected void LookAtCamera()
        {
                transform.LookAt(transform.position + Camera.main.transform.forward);  
        }
}