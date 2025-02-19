using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyStats: Stats
{

        [field: SerializeField] public float DropRate { get; private set; }

        public EnemyStats(EnemyStats stats)
        {
                this.Attack = stats.Attack;
                this.Speed = stats.Speed;
                this.Defend = stats.Defend;
                this.Health = stats.Health;
                this.Accuracy = stats.Accuracy;
                this.AttackSpeed = stats.AttackSpeed;
                this.Resistance = stats.Resistance;
                CanDealDebuffEffects = new List<DebuffEffect>();
                this.DropRate = stats.DropRate;
        }
}