using System;

[Serializable]
public abstract class Stats
{
    public int Speed;
    public int Attack;
    public float AttackSpeed;
    public int Defend;
    public int Health;
    public float Resistance;
    public float Accuracy;
    
    public override string ToString()
    {
        return $"Speed: {Speed}, Attack: {Attack}, AttackSpeed: {AttackSpeed}, " +
               $"Defend: {Defend}, Health: {Health}, Resistance: {Resistance}, Accuracy: {Accuracy}";
    }
}