using System;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBarUI: UIBase
{
        [field: SerializeField] protected Slider healthSlider;
        [field: SerializeField] protected Slider easeHealthSlider;
        [field: SerializeField] protected Slider healHealthSlider;
        protected Character character;

        [SerializeField]protected float lerpSpeed = 0.05f;

        protected bool getDam;


        protected virtual void Start()
        {
                character.OnMaxHealthChanged += UpdateMaxHealth;
                character.OnHealthDamaged += UpdateDamageHealth;
                character.OnHealthHealed += UpdateHealHealth;
        }
        
        protected virtual void FixedUpdate()
        {
                if (Mathf.Abs(healthSlider.value - easeHealthSlider.value) > 1 && getDam)
                {
                        // Debug.Log("Update ease");
                        easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, healthSlider.value, lerpSpeed);
                        healHealthSlider.value = easeHealthSlider.value;
                } else if (Mathf.Abs(healHealthSlider.value - healthSlider.value) > 1 && !getDam)
                {
                        healthSlider.value = Mathf.Lerp(healthSlider.value, healHealthSlider.value, lerpSpeed);
                        easeHealthSlider.value = healthSlider.value;
                }
                
                
        }

        protected virtual void UpdateDamageHealth(float current)
        {
                healthSlider.value = current;
                getDam = true;
        }

        protected virtual void UpdateMaxHealth(float max)
        {
                healthSlider.maxValue = max;
                easeHealthSlider.maxValue = max;
                healHealthSlider.maxValue = max;
        }
        
        protected virtual void UpdateHealHealth(float value)
        {
                healHealthSlider.value = value;
                getDam = false;
        }

        public void SetUpEaseHealthSlider(float value)
        {
                easeHealthSlider.value = value;
        }

        public void SetUpHealHealthSlider(float value)
        {
                healHealthSlider.value = value;
        }

        
        
        
}