using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats
{
    public int Speed;
    public int Attack;
    public float AttackSpeed;
    public int Defend;
    public int Health;
    public float Resistance;
    public float Accuracy;
    public List<DebuffEffect> CanDealDebuffEffects;
    public override string ToString()
    {
        return $"Speed: {Speed}, Attack: {Attack}, AttackSpeed: {AttackSpeed}, " +
               $"Defend: {Defend}, Health: {Health}, Resistance: {Resistance}, Accuracy: {Accuracy}";
    }

    public Stats Clone()
    {
        Stats newStats = new Stats
        {
            Speed = this.Speed,
            Attack = this.Attack,
            Defend = this.Defend,
            Health = this.Health,
            Resistance = this.Resistance,
            Accuracy = this.Accuracy,
            AttackSpeed = this.AttackSpeed,
            CanDealDebuffEffects = new List<DebuffEffect>(this.CanDealDebuffEffects)
            
        };
        return newStats;
    }
}