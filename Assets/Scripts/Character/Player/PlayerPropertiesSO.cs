using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPropsSO", menuName = "PlayerPropsSO", order = 0)]
public class PlayerPropertiesSO : ScriptableObject {

    [field: SerializeField] public PlayerStats BaseStats { get; private set; }
    
    [field: Header("Animation Parameters")]
    [field: SerializeField] public string IdleBoolTrigger { get; private set; }
    [field: SerializeField] public string MoveTrigger { get; private set; }
    [field: SerializeField] public string NomalAttackValueTrigger { get; private set; }
    [field: SerializeField] public string NomalAttackSpeedValue { get; private set; }
    [field: SerializeField] public string HitTrigger { get; private set; }
    [field: SerializeField] public string DeathTrigger { get; private set; }
    
    [field: SerializeField] public string IdleAnimationName { get; private set; }
    [field: SerializeField] public string MoveAnimationName { get; private set; }
    [field: SerializeField] public string HitAnimationName { get; private set; }
    [field: SerializeField] public string DeathAnimationName { get; private set; }

    [field: Header("Battle System")]
    [field: SerializeField] public LayerMask DamableLayers { get; private set; }
    




}
