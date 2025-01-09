using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectProps", menuName = "ObjectProps")]
public class PoolingObjectPropsSO : ScriptableObject
{
    [field: SerializeField] public List<ObjectPropsSO> ObjectPoolProps { get; private set; }
}