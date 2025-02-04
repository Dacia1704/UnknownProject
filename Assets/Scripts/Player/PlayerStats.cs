using System;
using UnityEngine;

[Serializable]
public class PlayerStats: Stats
{
    [field: SerializeField] public float BaseDashModifier { get; private set; }
    [field: SerializeField] public float BaseDashTime { get; private set; }
    [field: SerializeField] public float ResetNomalAttackTime { get; private set; }
}