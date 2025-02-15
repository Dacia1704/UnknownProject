using System;
using UnityEngine;

public class EnemyHealthBarUI: HealthBarUI
{
        private CanvasGroup canvasGroup;
        protected override void OnEnable()
        {
                character = GetComponentInParent<Character>();
                base.OnEnable();
        }

        private void Start()
        {
                canvasGroup = GetComponent<CanvasGroup>();
        }

        protected override void FixedUpdate()
        {
                if (Mathf.Abs(healthSlider.value - easeHealthSlider.value) > 1 && getDam)
                {
                        if (Mathf.Abs(healthSlider.value - easeHealthSlider.value) > healthSlider.maxValue * 0.05)
                        {
                                ShowHPBarUI();
                        }
                        easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, healthSlider.value, lerpSpeed);
                        healHealthSlider.value = easeHealthSlider.value;
                } else if (Mathf.Abs(healHealthSlider.value - healthSlider.value) > 1 && !getDam)
                {
                        if (Mathf.Abs(healHealthSlider.value - healthSlider.value) > healthSlider.maxValue * 0.05)
                        {
                                ShowHPBarUI();
                        }
                        healthSlider.value = Mathf.Lerp(healthSlider.value, healHealthSlider.value, lerpSpeed);
                        easeHealthSlider.value = healthSlider.value;
                }
                else
                {
                        HideHPBarUI();
                }
                
                
        }

        private void LateUpdate()
        {
                LookAtCamera();
        }
        
        protected void LookAtCamera()
        {
                transform.LookAt(transform.position + Camera.main.transform.forward);  
        }

        public void HideHPBarUI()
        {
                canvasGroup.alpha = 0;
        }

        public void ShowHPBarUI()
        {
                canvasGroup.alpha = 1;
        }
}