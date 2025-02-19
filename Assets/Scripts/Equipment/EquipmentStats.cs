using System;
using System.Collections.Generic;

public enum EquimentType
{
    Weapon, // Attack
    Armor, // Def
    Necklace, // Hp
    Boots, // Spd
    Cloak, // AtkSpd, Acc, Res
}

public enum WeaponType
{
    Fighter,
    Sword,
    Staff,
    Bow,
}

public enum EquipmentSet
{
    Primordial, //tăng attack all lên 15% bộ4
    Guardian, //tăng HP, Def lên 10% bộ2
    Elemental, // có thể gây hiệu ứng poison, burn, frozen theo acc bộ 4
}

public static class EquipmentStatsRange
{
    
    public static Tuple<int,int> MainSpeed  = Tuple.Create(10, 20);
    public static Tuple<int,int> MainAttack  = Tuple.Create(50, 100);
    public static Tuple<int,int> MainDefend  = Tuple.Create(50, 70);
    public static Tuple<int,int> MainHealth  = Tuple.Create(1700, 2700);
    public static Tuple<float,float> MainResistance  = Tuple.Create(0.40f, 0.70f);
    public static Tuple<float,float> MainAttackSpeed  = Tuple.Create(2.01f, 4.01f);
    public static Tuple<float,float> MainAccuracy  = Tuple.Create(0.40f, 0.70f);
    
    public static Tuple<int,int> Speed  = Tuple.Create(1,5);
    public static Tuple<int,int> Attack  = Tuple.Create(1, 30);
    public static Tuple<float,float> AttackSpeed  = Tuple.Create(0.01f, 1.01f);
    public static Tuple<int,int> Defend  = Tuple.Create(1, 50);
    public static Tuple<int,int> Health  = Tuple.Create(500, 1500);
    public static Tuple<float,float> Resistance  = Tuple.Create(0.01f, 0.20f);
    public static Tuple<float,float> Accuracy  = Tuple.Create(0.01f, 0.20f);
    
}



[Serializable]
public class EquipmentStats: Stats
{
    public EquipmentStats()
    {
        Speed = 0;
        Attack = 0;
        Health = 0;
        Defend = 0;
        AttackSpeed = 0;
        Accuracy = 0;
        Resistance = 0;
        CanDealDebuffEffects = new List<DebuffEffect>();
    }
}