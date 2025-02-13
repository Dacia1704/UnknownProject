using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    private EnemyPooling enemyPooling;

    private List<SpawnPoint> spawnPointsList; 

    public List<Enemy> EnemiesList { get; private set; }

    private void Start()
    {
        EnemiesList = new List<Enemy>();
        enemyPooling = GetComponentInChildren<EnemyPooling>();
        spawnPointsList = GetComponentsInChildren<SpawnPoint>().ToList();
        StartCoroutine(SpawnEnemyCoroutine());
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            SpawnEnemy();
        }
    }
    
    


    public void SpawnEnemy()
    {
        GameObject enemy = enemyPooling.GetRandomEnemy();
        AddEnemyToList(enemy.GetComponent<Enemy>());
        int randomPoint = Random.Range(0, spawnPointsList.Count);
        enemy.transform.position = new Vector3(spawnPointsList[randomPoint].transform.position.x,
            enemy.transform.position.y, spawnPointsList[randomPoint].transform.position.z);
    }
    

    public void AddEnemyToList(Enemy enemy)
    {
        EnemiesList.Add(enemy);
    }

    public void RemoveEnemyFromList(Enemy enemy)
    {
        EnemiesList.Remove(enemy);
    }
    
    
    
    
    
}
