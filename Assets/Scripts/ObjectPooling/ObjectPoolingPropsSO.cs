using System;
using System.Collections.Generic;
using UnityEngine;

// props of pool 
[CreateAssetMenu(fileName = "ObjectPoolingProps", menuName = "ObjectPoolingProps")]
public class ObjectPoolingPropsSO : ScriptableObject
{
    [field: SerializeField] public List<PoolingObjectPropsSO> PoolingObjectList { get; private set; }
}