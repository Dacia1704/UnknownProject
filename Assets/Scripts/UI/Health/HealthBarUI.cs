using System;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI: UIBase
{
        [field: SerializeField] private Slider healthSlider;
        [field: SerializeField] private Slider easeHealthSlider;
        private Character character;

        [SerializeField]private float lerpSpeed = 0.05f;
        private void Start()
        {
                character = GetComponentInParent<Character>();
                character.OnHealthChanged += UpdateHealth;
                
        }

        private void FixedUpdate()
        {
                if (Mathf.Abs(healthSlider.value - easeHealthSlider.value) > 1)
                {
                        // Debug.Log("Update ease " + Mathf.Abs(healthSlider.value - easeHealthSlider.value));
                        easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, healthSlider.value, lerpSpeed);
                }
        }

        private void LateUpdate()
        {
                transform.LookAt(transform.position + Camera.main.transform.forward);
        }

        private void UpdateHealth(float max,float current)
        {
                healthSlider.maxValue = max;
                healthSlider.value = current;
                
                easeHealthSlider.maxValue = max;

        }

        public void SetUpEaseHealthSlider(float value)
        {
                easeHealthSlider.value = value;
        }
        
        
}