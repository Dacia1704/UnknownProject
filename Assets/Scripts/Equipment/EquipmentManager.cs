using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EquipmentManager : MonoBehaviour
{
        private float dropRate;
        
        public void SetDropRate(float dropRate)
        {
                this.dropRate = dropRate;
        }

        public void Drop()
        {
                WeaponType randomType = GetRandomWeaponType();
                
        }

        public WeaponType GetRandomWeaponType()
        {
                int numberOfType = Enum.GetValues(typeof(WeaponType)).Length;
                
                int randomType = Random.Range(0, numberOfType);

                return (WeaponType)randomType;
        }

        public WeaponStats GetRandomWeaponStats(WeaponType type)
        {
                WeaponStats randomallStats = new();
                if(type == )
        }
}