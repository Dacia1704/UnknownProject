using System;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public Player Player { get; private set; }
    public List<Enemy> EnemiesList { get; private set; } 

    private void Awake()
    {
        instance = this;

        Player = FindObjectOfType<Player>();

        EnemiesList = new List<Enemy>();
        ResetEnemiesList();
    }


    public void ResetEnemiesList()
    {
        EnemiesList.Clear();
        EnemiesList = new List<Enemy>(FindObjectsByType<Enemy>(FindObjectsInactive.Include, FindObjectsSortMode.None));
    }

    public void AddEnemiesList(Enemy newEnemy)
    {
        if (!EnemiesList.Contains(newEnemy))
        {
            EnemiesList.Add(newEnemy);
        }
    }
    public void RemoveEnemiesList(Enemy removeEnemy)
    {
        EnemiesList.Remove(removeEnemy);
    }
}