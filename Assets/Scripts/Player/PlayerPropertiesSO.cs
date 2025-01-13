using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPropsSO", menuName = "PlayerPropsSO", order = 0)]
public class PlayerPropertiesSO : ScriptableObject {

    [field: SerializeField] public Stats BaseStats { get; private set; }


    [field: SerializeField] public float BaseDashModifier { get; private set; }
    [field: SerializeField] public float BaseDashTime { get; private set; }
    [field: SerializeField] public float ResetNomalAttackTime { get; private set; }
    
    
    [field: Header("Animation Parameters")]
    [field: SerializeField] public string IdleBoolTrigger { get; private set; }
    [field: SerializeField] public string MoveTrigger { get; private set; }
    [field: SerializeField] public string NomalAttackValueTrigger { get; private set; }
    
    [field: SerializeField] public string IdleAnimationName { get; private set; }
    [field: SerializeField] public string MoveAnimationName { get; private set; }

    [field: Header("Battle System")]
    [field: SerializeField] public List<string> TagCanDealDamList { get; private set; }
    




}
