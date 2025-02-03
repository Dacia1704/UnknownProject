using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EquipmentManager : MonoBehaviour
{
        public static EquipmentManager instance;

        [HideInInspector] public EquipmentPooling EquipmentPooling;
        [field:SerializeField ]public List<EquipmentData> InventoryItems { get; private set; }

        private float dropRate = 1f;
        
        public void SetDropRate(float dropRate)
        {
                this.dropRate = dropRate;
        }
        
        private void Awake()
        {
                instance = this;
                InventoryItems = new List<EquipmentData>();
        }

        private void OnEnable()
        {
                EquipmentPooling = GetComponentInChildren<EquipmentPooling>();
        }

        private void Start()
        {
                
                StartCoroutine(GenEquipment());
        }

        private IEnumerator GenEquipment()
        {
                while (true)
                {
                        yield return new WaitForSeconds(2);
                        RandomDrop();
                        
                }
        }


        #region Drop Equipment 
        public void RandomDrop()
        {
                EquipmentSet equipmentSet = GetRandomEquipmentProp();
                EquimentType equimentType = GetRandomEquimentType();
                // EquimentType equimentType = EquimentType.Weapon;
                WeaponType weaponType = GetRandomWeaponType();
                // WeaponType weaponType = WeaponType.Sword;

                EquipmentStats equipmentStats = GetRandomEquipmentStats(equimentType);
                // Debug.Log(equipmentSet.ToString() +" "+ equimentType.ToString() +" " +weaponType.ToString() +" " + equipmentStats.ToString());
                GameObject equipment = EquipmentPooling.GetEquipment(equipmentSet,equimentType,weaponType);
                equipment.GetComponent<Equipment>().EquipmentStats = equipmentStats;
        }
        public WeaponType GetRandomWeaponType()
        {
                int numberOfType = Enum.GetValues(typeof(WeaponType)).Length;
                
                int randomType = Random.Range(1, numberOfType); // except fighter

                return (WeaponType)randomType;
        }
        public EquimentType GetRandomEquimentType()
        {
                int numberOfType = Enum.GetValues(typeof(EquimentType)).Length;
                
                int randomType = Random.Range(0, numberOfType);

                return (EquimentType)randomType; 
        }
        public EquipmentSet GetRandomEquipmentProp()
        {
                int numberOfProp = Enum.GetValues(typeof(EquipmentSet)).Length;
                int randomProp = Random.Range(0, numberOfProp);
                return (EquipmentSet)randomProp;
        }
        
        public EquipmentStats GetRandomEquipmentStats(EquimentType type)
        {
                if (type == EquimentType.Weapon)
                {
                        return GetRandomWeaponStats();

                } else if (type == EquimentType.Armor)
                {
                        return GetRandomArmorStats();
                } else if (type == EquimentType.Necklace)
                {
                        return GetRandomNecklaceStats();
                } else if (type == EquimentType.Boots)
                {
                        return GetRandomBootsStats();
                }

                return GetRandomCloakStats();
        }
        public EquipmentStats GetRandomWeaponStats()
        {
                EquipmentStats randomStats = new();
                randomStats.Attack = Random.Range(EquipmentStatsRange.MainAttack.Item1,EquipmentStatsRange.MainAttack.Item2);
                
                randomStats.Speed = Random.Range(EquipmentStatsRange.Speed.Item1,EquipmentStatsRange.Speed.Item2);
                randomStats.AttackSpeed = Random.Range(EquipmentStatsRange.AttackSpeed.Item1,EquipmentStatsRange.AttackSpeed.Item2);
                randomStats.Defend = Random.Range(EquipmentStatsRange.Defend.Item1,EquipmentStatsRange.Defend.Item2);
                randomStats.Health = Random.Range(EquipmentStatsRange.Health.Item1,EquipmentStatsRange.Health.Item2);
                randomStats.Accuracy = Random.Range(EquipmentStatsRange.Accuracy.Item1,EquipmentStatsRange.Accuracy.Item2);
                randomStats.Resistance = Random.Range(EquipmentStatsRange.Resistance.Item1,EquipmentStatsRange.Resistance.Item2);
                
                
                List<Action> stats = new List<Action>
                {
                        () => randomStats.Speed = 0,
                        () => randomStats.AttackSpeed = 0,
                        () => randomStats.Defend = 0,
                        () => randomStats.Health = 0,
                        () => randomStats.Resistance = 0,
                        () => randomStats.Accuracy = 0
                };

                int firstIndex = Random.Range(0, stats.Count);
                int secondIndex = 0;
                do
                {
                        secondIndex = Random.Range(0, stats.Count);
                } while (secondIndex == firstIndex);

                stats[firstIndex]();
                stats[secondIndex]();
                
                return randomStats;
        }
        public EquipmentStats GetRandomArmorStats()
        {
                EquipmentStats randomStats = new();
                randomStats.Defend = Random.Range(EquipmentStatsRange.MainDefend.Item1,EquipmentStatsRange.MainDefend.Item2);
                
                randomStats.Speed = Random.Range(EquipmentStatsRange.Speed.Item1,EquipmentStatsRange.Speed.Item2);
                randomStats.AttackSpeed = Random.Range(EquipmentStatsRange.AttackSpeed.Item1,EquipmentStatsRange.AttackSpeed.Item2);
                randomStats.Attack = Random.Range(EquipmentStatsRange.Attack.Item1,EquipmentStatsRange.Attack.Item2);
                randomStats.Health = Random.Range(EquipmentStatsRange.Health.Item1,EquipmentStatsRange.Health.Item2);
                randomStats.Accuracy = Random.Range(EquipmentStatsRange.Accuracy.Item1,EquipmentStatsRange.Accuracy.Item2);
                randomStats.Resistance = Random.Range(EquipmentStatsRange.Resistance.Item1,EquipmentStatsRange.Resistance.Item2);
                
                
                List<Action> stats = new List<Action>
                {
                        () => randomStats.Speed = 0,
                        () => randomStats.Attack = 0,
                        () => randomStats.AttackSpeed = 0,
                        () => randomStats.Health = 0,
                        () => randomStats.Resistance = 0,
                        () => randomStats.Accuracy = 0
                };

                int firstIndex = Random.Range(0, stats.Count);
                int secondIndex = 0;
                do
                {
                        secondIndex = Random.Range(0, stats.Count);
                } while (secondIndex == firstIndex);

                stats[firstIndex]();
                stats[secondIndex]();
                
                return randomStats;
        }
        public EquipmentStats GetRandomNecklaceStats()
        {
                EquipmentStats randomStats = new();
                randomStats.Health = Random.Range(EquipmentStatsRange.MainHealth.Item1,EquipmentStatsRange.MainHealth.Item2);
                
                randomStats.Speed = Random.Range(EquipmentStatsRange.Speed.Item1,EquipmentStatsRange.Speed.Item2);
                randomStats.AttackSpeed = Random.Range(EquipmentStatsRange.AttackSpeed.Item1,EquipmentStatsRange.AttackSpeed.Item2);
                randomStats.Attack = Random.Range(EquipmentStatsRange.Attack.Item1,EquipmentStatsRange.Attack.Item2);
                randomStats.Defend = Random.Range(EquipmentStatsRange.Defend.Item1,EquipmentStatsRange.Defend.Item2);
                randomStats.Accuracy = Random.Range(EquipmentStatsRange.Accuracy.Item1,EquipmentStatsRange.Accuracy.Item2);
                randomStats.Resistance = Random.Range(EquipmentStatsRange.Resistance.Item1,EquipmentStatsRange.Resistance.Item2);
                
                
                List<Action> stats = new List<Action>
                {
                        () => randomStats.Speed = 0,
                        () => randomStats.Attack = 0,
                        () => randomStats.AttackSpeed = 0,
                        () => randomStats.Defend = 0,
                        () => randomStats.Resistance = 0,
                        () => randomStats.Accuracy = 0
                };

                int firstIndex = Random.Range(0, stats.Count);
                int secondIndex = 0;
                do
                {
                        secondIndex = Random.Range(0, stats.Count);
                } while (secondIndex == firstIndex);

                stats[firstIndex]();
                stats[secondIndex]();
                
                return randomStats;
        }
        public EquipmentStats GetRandomBootsStats()
        {
                EquipmentStats randomStats = new();
                randomStats.Speed = Random.Range(EquipmentStatsRange.MainSpeed.Item1,EquipmentStatsRange.MainSpeed.Item2);
                
                randomStats.Defend = Random.Range(EquipmentStatsRange.Defend.Item1,EquipmentStatsRange.Defend.Item2);
                randomStats.AttackSpeed = Random.Range(EquipmentStatsRange.AttackSpeed.Item1,EquipmentStatsRange.AttackSpeed.Item2);
                randomStats.Attack = Random.Range(EquipmentStatsRange.Attack.Item1,EquipmentStatsRange.Attack.Item2);
                randomStats.Health = Random.Range(EquipmentStatsRange.Health.Item1,EquipmentStatsRange.Health.Item2);
                randomStats.Accuracy = Random.Range(EquipmentStatsRange.Accuracy.Item1,EquipmentStatsRange.Accuracy.Item2);
                randomStats.Resistance = Random.Range(EquipmentStatsRange.Resistance.Item1,EquipmentStatsRange.Resistance.Item2);
                
                
                List<Action> stats = new List<Action>
                {
                        () => randomStats.Defend = 0,
                        () => randomStats.Attack = 0,
                        () => randomStats.AttackSpeed = 0,
                        () => randomStats.Health = 0,
                        () => randomStats.Resistance = 0,
                        () => randomStats.Accuracy = 0
                };

                int firstIndex = Random.Range(0, stats.Count);
                int secondIndex = 0;
                do
                {
                        secondIndex = Random.Range(0, stats.Count);
                } while (secondIndex == firstIndex);

                stats[firstIndex]();
                stats[secondIndex]();
                
                return randomStats;
        }
        public EquipmentStats GetRandomCloakStats()
        {
                EquipmentStats randomStats = new();
                
                int random =  Random.Range(1, 4);
                if (random == 1)
                {
                        randomStats.AttackSpeed = Random.Range(EquipmentStatsRange.MainAttackSpeed.Item1,EquipmentStatsRange.MainAttackSpeed.Item2);
                        
                        randomStats.Speed = Random.Range(EquipmentStatsRange.Speed.Item1,EquipmentStatsRange.Speed.Item2);
                        randomStats.Defend = Random.Range(EquipmentStatsRange.Defend.Item1,EquipmentStatsRange.Defend.Item2);
                        randomStats.Attack = Random.Range(EquipmentStatsRange.Attack.Item1,EquipmentStatsRange.Attack.Item2);
                        randomStats.Health = Random.Range(EquipmentStatsRange.Health.Item1,EquipmentStatsRange.Health.Item2);
                        randomStats.Accuracy = Random.Range(EquipmentStatsRange.Accuracy.Item1,EquipmentStatsRange.Accuracy.Item2);
                        randomStats.Resistance = Random.Range(EquipmentStatsRange.Resistance.Item1,EquipmentStatsRange.Resistance.Item2);
                        
                        
                        List<Action> stats1 = new List<Action>
                        {
                                () => randomStats.Speed = 0,
                                () => randomStats.Attack = 0,
                                () => randomStats.Defend = 0,
                                () => randomStats.Health = 0,
                                () => randomStats.Resistance = 0,
                                () => randomStats.Accuracy = 0
                        };

                        int firstIndex1 = Random.Range(0, stats1.Count);
                        int secondIndex1 = 0;
                        do
                        {
                                secondIndex1 = Random.Range(0, stats1.Count);
                        } while (secondIndex1 == firstIndex1);

                        stats1[firstIndex1]();
                        stats1[secondIndex1]();
                        
                        return randomStats;
                        
                } else if (random == 2)
                {
                        randomStats.Resistance = Random.Range(EquipmentStatsRange.MainResistance.Item1,EquipmentStatsRange.MainResistance.Item2);
                        
                        randomStats.Speed = Random.Range(EquipmentStatsRange.Speed.Item1,EquipmentStatsRange.Speed.Item2);
                        randomStats.Defend = Random.Range(EquipmentStatsRange.Defend.Item1,EquipmentStatsRange.Defend.Item2);
                        randomStats.Attack = Random.Range(EquipmentStatsRange.Attack.Item1,EquipmentStatsRange.Attack.Item2);
                        randomStats.Health = Random.Range(EquipmentStatsRange.Health.Item1,EquipmentStatsRange.Health.Item2);
                        randomStats.Accuracy = Random.Range(EquipmentStatsRange.Accuracy.Item1,EquipmentStatsRange.Accuracy.Item2);
                        randomStats.AttackSpeed = Random.Range(EquipmentStatsRange.AttackSpeed.Item1,EquipmentStatsRange.AttackSpeed.Item2);
                        
                        
                        List<Action> stats2 = new List<Action>
                        {
                                () => randomStats.Speed = 0,
                                () => randomStats.Attack = 0,
                                () => randomStats.Defend = 0,
                                () => randomStats.Health = 0,
                                () => randomStats.AttackSpeed = 0,
                                () => randomStats.Accuracy = 0
                        };

                        int firstIndex2 = Random.Range(0, stats2.Count);
                        int secondIndex2 = 0;
                        do
                        {
                                secondIndex2 = Random.Range(0, stats2.Count);
                        } while (secondIndex2 == firstIndex2);

                        stats2[firstIndex2]();
                        stats2[secondIndex2]();
                        
                        return randomStats;
                }
                randomStats.Accuracy = Random.Range(EquipmentStatsRange.MainAccuracy.Item1,EquipmentStatsRange.MainAccuracy.Item2);
                        
                randomStats.Speed = Random.Range(EquipmentStatsRange.Speed.Item1,EquipmentStatsRange.Speed.Item2);
                randomStats.Defend = Random.Range(EquipmentStatsRange.Defend.Item1,EquipmentStatsRange.Defend.Item2);
                randomStats.Attack = Random.Range(EquipmentStatsRange.Attack.Item1,EquipmentStatsRange.Attack.Item2);
                randomStats.Health = Random.Range(EquipmentStatsRange.Health.Item1,EquipmentStatsRange.Health.Item2);
                randomStats.AttackSpeed = Random.Range(EquipmentStatsRange.AttackSpeed.Item1,EquipmentStatsRange.AttackSpeed.Item2);
                randomStats.Resistance = Random.Range(EquipmentStatsRange.Resistance.Item1,EquipmentStatsRange.Resistance.Item2);
                        
                        
                List<Action> stats = new List<Action>
                {
                        () => randomStats.Speed = 0,
                        () => randomStats.Attack = 0,
                        () => randomStats.Defend = 0,
                        () => randomStats.Health = 0,
                        () => randomStats.Resistance = 0,
                        () => randomStats.AttackSpeed = 0
                };

                int firstIndex = Random.Range(0, stats.Count);
                int secondIndex = 0;
                do
                {
                        secondIndex = Random.Range(0, stats.Count);
                } while (secondIndex == firstIndex);

                stats[firstIndex]();
                stats[secondIndex]();
                        
                return randomStats;
                
        }
        #endregion
        
        #region CollectEquipment
        
        public void CollectEquipment(GameObject equipmentOb)
        {
                AddItem(equipmentOb.GetComponent<Equipment>());
                EquipmentPooling.ReleaseObject(equipmentOb);

                Debug.LogError(InventoryItems.Count);
                foreach (var data in InventoryItems)
                {
                        Debug.Log(data);
                }
        }
        
        private void AddItem(Equipment item)
        {
                InventoryItems.Add(new EquipmentData(item.EquipmentPropsSO,item.EquipmentStats));
        }

        // private void RemoveItem(Equipment item)
        // {
        //         InventoryItems.Remove(item);
        // }
        
        #endregion
}