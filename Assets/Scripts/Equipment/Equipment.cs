using UnityEngine;

public class Equipment :MonoBehaviour, IPoolingObject
{
    [field: SerializeField] public PoolingObjectPropsSO PoolingObjectPropsSO { get; set; }
}