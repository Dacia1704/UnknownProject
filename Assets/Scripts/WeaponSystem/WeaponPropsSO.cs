using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Fighter,
    Sword,
    Staff,
    Bow,
}


[CreateAssetMenu(fileName = "WeaponPropsSO", menuName = "WeaponPropsSO", order = 0)]
public class WeaponPropsSO : ObjectPropsSO
{
    public float Damage;
    public WeaponType Type;
    public Sprite Icon;
}

