using System;
using System.Collections.Generic;

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
        Stats newStats = new Stats();
        newStats.Speed = this.Speed;
        newStats.Attack = this.Attack;
        newStats.Defend = this.Defend;
        newStats.Health = this.Health;
        newStats.Resistance = this.Resistance;
        newStats.Accuracy = this.Accuracy;
        newStats.AttackSpeed = this.AttackSpeed;
        newStats.CanDealDebuffEffects = new List<DebuffEffect>(this.CanDealDebuffEffects);
        return newStats;
    }
}