using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStats: Stats
{
    [field: SerializeField] public float BaseDashModifier { get; private set; }
    [field: SerializeField] public float BaseDashTime { get; private set; }
    [field: SerializeField] public float ResetNomalAttackComboCooldown { get; private set; }
    [field: SerializeField] public float HitCooldown { get; private set; }
    [field: SerializeField] public float DashCooldown { get; private set; }


    public PlayerStats(PlayerStats stats)
    {
        Speed = stats.Speed;
        Attack = stats.Attack;
        Health = stats.Health;
        Defend = stats.Defend;
        AttackSpeed = stats.AttackSpeed;
        Accuracy = stats.Accuracy;
        Resistance = stats.Resistance;
        CanDealDebuffEffects = new List<DebuffEffect>(stats.CanDealDebuffEffects);
        BaseDashModifier = stats.BaseDashModifier;
        BaseDashTime = stats.BaseDashTime;
        ResetNomalAttackComboCooldown = stats.ResetNomalAttackComboCooldown;
    }
    public PlayerStats(PlayerStats stats,int currentHP)
    {
        Speed = stats.Speed;
        Attack = stats.Attack;
        Health = currentHP;
        Defend = stats.Defend;
        AttackSpeed = stats.AttackSpeed;
        Accuracy = stats.Accuracy;
        Resistance = stats.Resistance;
        CanDealDebuffEffects = new List<DebuffEffect>(stats.CanDealDebuffEffects);
        BaseDashModifier = stats.BaseDashModifier;
        BaseDashTime = stats.BaseDashTime;
        ResetNomalAttackComboCooldown = stats.ResetNomalAttackComboCooldown;
    }
    public PlayerStats()
    {
        Speed = 0;
        Attack = 0;
        Health = 0;
        Defend = 0;
        AttackSpeed = 0;
        Accuracy = 0;
        Resistance = 0;
        CanDealDebuffEffects = new List<DebuffEffect>();
        BaseDashModifier = 0;
        BaseDashTime = 0;
        ResetNomalAttackComboCooldown = 0;
    }
    
    public PlayerStats(PlayerStats baseStats, PlayerStats bonusStats)
    {
        Speed = baseStats.Speed + bonusStats.Speed;
        Attack = baseStats.Attack +bonusStats.Attack;
        Health = baseStats.Health + bonusStats.Health;
        Defend = baseStats.Defend + bonusStats.Defend;
        AttackSpeed = baseStats.AttackSpeed + bonusStats.AttackSpeed;
        Accuracy = baseStats.Accuracy + bonusStats.Accuracy; 
        Resistance = baseStats.Resistance + bonusStats.Resistance;
        CanDealDebuffEffects = baseStats.CanDealDebuffEffects;
        BaseDashModifier = baseStats.BaseDashModifier;
        BaseDashTime = baseStats.BaseDashTime;
        ResetNomalAttackComboCooldown = baseStats.ResetNomalAttackComboCooldown;
    }
}