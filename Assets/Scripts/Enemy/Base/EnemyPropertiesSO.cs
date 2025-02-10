using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyPropertiesSO", menuName = "EnemyPropertiesSO", order = 0)]
public class EnemyPropertiesSO : ScriptableObject {
    [field: SerializeField] public EnemyStats BaseStats { get;private set; }

    [field: SerializeField] public string IdleAnimationName { get; private set; }
    [field: SerializeField] public string MoveAnimationName { get; private set; }
    [field: SerializeField] public string AttackAnimationName { get; private set; }
    [field: SerializeField] public string HitAnimationName { get; private set; }
    [field: SerializeField] public string DieAnimationName { get; private set; }
    [field: SerializeField] public LayerMask DamableLayers { get; private set; }
    [field: SerializeField] public float BaseDistanceTrigger { get; private set; }
    [field: SerializeField] public float DetectModifierDistance { get; private set; }
    [field: SerializeField] public float AttackDistance { get; private set; }
    [field: SerializeField] public float AttackCooldown { get; private set; }
}