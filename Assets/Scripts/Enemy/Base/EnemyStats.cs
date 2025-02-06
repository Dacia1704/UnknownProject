using System;
using UnityEngine;

[Serializable]
public class EnemyStats: Stats
{
        [field: SerializeField] public float BaseDistanceTrigger { get; private set; }
        [field: SerializeField] public float DropRate { get; private set; }
}