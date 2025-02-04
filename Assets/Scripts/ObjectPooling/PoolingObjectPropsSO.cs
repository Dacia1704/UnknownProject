using UnityEngine;

// props of object to pool
public abstract class PoolingObjectPropsSO : ScriptableObject
{
    public string KeyObject;
    public GameObject ObjectPrefab;
}