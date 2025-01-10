using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPropsSO", menuName = "PlayerPropsSO", order = 0)]
public class PlayerPropertiesSO : ScriptableObject {
    [field: SerializeField] public float BaseSpeed { get; private set; }
    [field: SerializeField] public float BaseAttack {get; private set; }
    [field: SerializeField] public float BaseDashSpeed { get; private set; }
    [field: SerializeField] public float BaseDashTime { get; private set; }
    [field: SerializeField] public float ResetNomalAttackTime { get; private set; }
    
    
    [field: Header("Animation Parameters")]
    [field: SerializeField] public string IdleBoolTrigger { get; private set; }
    [field: SerializeField] public string MoveTrigger { get; private set; }
    [field: SerializeField] public string NomalAttackValueTrigger { get; private set; }
    
    [field: SerializeField] public string IdleAnimationName { get; private set; }
    [field: SerializeField] public string MoveAnimationName { get; private set; }
    




}
