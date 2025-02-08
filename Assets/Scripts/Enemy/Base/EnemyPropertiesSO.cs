using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyPropertiesSO : ScriptableObject {
    [field: SerializeField] public EnemyStats BaseStats { get;private set; }

    [field: SerializeField] public string IdleTrigger { get; private set; }
    [field: SerializeField] public string MoveTrigger { get; private set; }
    [field: SerializeField] public LayerMask DamableLayers { get; private set; }
}