using UnityEngine;

[CreateAssetMenu(fileName = "BulletPropsSO", menuName = "BulletPropsSO", order = 0)]
public class BulletPropsSO:PoolingObjectPropsSO
{
        [field: SerializeField] public float TimeRemainAfterHit { get; private set; }
}