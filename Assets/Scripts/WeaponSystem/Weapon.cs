using UnityEngine;

public class Weapon :MonoBehaviour, PoolingObject
{
    [field: SerializeField] public ObjectPropsSO ObjectPropsSO { get; set; }
}