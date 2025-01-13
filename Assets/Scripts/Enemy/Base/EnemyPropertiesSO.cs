using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyPropertiesSO : ScriptableObject {
    [field: SerializeField] public float BaseSpeed { get; private set; }
    [field: SerializeField] public int BaseHealth { get; private set; }
    [field: SerializeField] public float BaseAttack { get; private set; }

    [field: SerializeField] public string IdleTrigger { get; private set; }
    [field: SerializeField] public string MoveTrigger { get; private set; }

    [field: SerializeField] public float BaseDistanceTrigger { get; private set; }

    [field: SerializeField] public List<string> TagCanDealDamList { get; private set; }
}