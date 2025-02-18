
using UnityEngine;
using UnityEngine.Pool;

public class EquipmentPooling: ObjectPooling
{
    [SerializeField] private ObjectPoolPropsSO bulletPoolPropsSO;
    public string GetKeyObjectEquiment(EquipmentSet set,EquimentType type,WeaponType wtype)
    {
        if (type == EquimentType.Weapon)
        {
            if (wtype == WeaponType.Fighter) return "Fighter";
            return set.ToString() + wtype.ToString();
        }
        return set.ToString() + type.ToString();
    }
    
    public string GetKeyObjectBulletEquiment(EquipmentSet set,EquimentType type,WeaponType wtype)
    {
        if (type == EquimentType.Weapon)
        {
            if (wtype == WeaponType.Fighter) return "FighterBullet";
            return set.ToString() + wtype.ToString() +"Bullet";
        }
        return set.ToString() + type.ToString() +"Bullet";
    }

    public GameObject GetEquipment(EquipmentSet set, EquimentType type,WeaponType wtype)
    {
        return GetObject(GetKeyObjectEquiment(set, type,wtype));
    }
    public GameObject GetBulletEquipment(EquipmentSet set, EquimentType type, WeaponType wtype)
    {
        string keyObject = GetKeyObjectBulletEquiment(set, type,wtype);
        
        if (pools.ContainsKey(keyObject))
        {
            return pools[keyObject].Get();
        }
        pools[keyObject] = new ObjectPool<GameObject>(
            createFunc: () =>
            {
                PoolingObjectPropsSO objProps = bulletPoolPropsSO.PoolingObjectList.Find(obj => obj.KeyObject == keyObject);
                return Instantiate(objProps.ObjectPrefab,transform);
            },
            actionOnGet: obj => obj.SetActive(true),
            actionOnRelease: obj => obj.SetActive(false),
            actionOnDestroy: Destroy,
            collectionCheck: false,
            defaultCapacity: 10,
            maxSize: 50
        );
        return pools[keyObject].Get();
    }

    public void ReleaseBulletEquipment(GameObject bulletOb)
    {
        string keyObjectToRealse = bulletOb.GetComponent<IPoolingObject>().PoolingObjectPropsSO.KeyObject;
        string keyObject = bulletPoolPropsSO.PoolingObjectList.Find(obj => obj.KeyObject == keyObjectToRealse).KeyObject;
        bulletOb.transform.SetParent(transform);
        pools[keyObject].Release(bulletOb);
    }
    
}