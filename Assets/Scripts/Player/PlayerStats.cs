using System;
using UnityEngine;

[Serializable]
public class PlayerStats: Stats
{
    [field: SerializeField] public float BaseDashModifier { get; private set; }
    [field: SerializeField] public float BaseDashTime { get; private set; }
    [field: SerializeField] public float ResetNomalAttackTime { get; private set; }


    public PlayerStats(PlayerStats stats)
    {
        Speed = stats.Speed;
        Attack = stats.Attack;
        Health = stats.Health;
        Defend = stats.Defend;
        AttackSpeed = stats.AttackSpeed;
        Accuracy = stats.Accuracy;
        Resistance = stats.Resistance;
        BaseDashModifier = stats.BaseDashModifier;
        BaseDashTime = stats.BaseDashTime;
        ResetNomalAttackTime = stats.ResetNomalAttackTime;
    }
}