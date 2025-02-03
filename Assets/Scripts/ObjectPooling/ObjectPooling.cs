using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;


public abstract class ObjectPooling: MonoBehaviour
{
    protected Dictionary<string, ObjectPool<GameObject>> pools;

    [SerializeField] protected ObjectPoolingPropsSO objectPoolingProps;
    

    private void Awake()
    {
        pools = new Dictionary<string,ObjectPool<GameObject>>();
    }

    public GameObject GetObject(string keyObject)
    {
        if (pools.ContainsKey(keyObject))
        {
            return pools[keyObject].Get();
        }
        pools[keyObject] = new ObjectPool<GameObject>(
            createFunc: () =>
            {
                PoolingObjectPropsSO objProps = objectPoolingProps.PoolingObjectList.Find(obj => obj.KeyObject == keyObject);
                return Instantiate(objProps.ObjectPrefab,transform);
            },
            actionOnGet: obj => obj.SetActive(true),
            actionOnRelease: obj => obj.SetActive(false),
            actionOnDestroy: Destroy,
            collectionCheck: false,
            defaultCapacity: 10,
            maxSize: 20
        );
        return pools[keyObject].Get();
    }

    public void ReleaseObject(GameObject objectToRealse)
    {
        string keyObjectToRealse = objectToRealse.GetComponent<Equipment>().EquipmentPropsSO.KeyObject;
        string keyObject = objectPoolingProps.PoolingObjectList.Find(obj => obj.KeyObject == keyObjectToRealse).KeyObject;
        objectToRealse.transform.SetParent(transform);
        pools[keyObject].Release(objectToRealse);
    }
}