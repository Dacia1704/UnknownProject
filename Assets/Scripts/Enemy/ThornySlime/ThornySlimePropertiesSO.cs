using UnityEngine;

[CreateAssetMenu(fileName = "ThornySlimePropertiesSO", menuName = "ThornySlimePropertiesSO", order = 0)]
public class ThornySlimePropertiesSO: EnemyPropertiesSO
{
        [field: SerializeField] public string DefendAnimationName { get; set; }
        [field: SerializeField] public string HitDefendAnimationName { get; set; }
        [field: SerializeField] public float DefendDetectDistance { get; private set; }
}