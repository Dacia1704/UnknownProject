using UnityEngine;

public class EnemyPooling : ObjectPooling
{
        public GameObject GetRandomEnemy()
        {
                int random = Random.Range(0, objectPoolProps.PoolingObjectList.Count);
                return GetObject(objectPoolProps.PoolingObjectList[random].KeyObject);
        }

        public GameObject GetEnemy(string keyObject)
        {
                return GetObject(keyObject);
        }

        public void ReturnEnemyToPool(GameObject enemyObject)
        {
                enemyObject.SetActive(false);
                ReleaseObject(enemyObject);
        }
}