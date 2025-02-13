using System;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public Player Player { get; private set; }
    public EnemyManager EnemyManager { get; private set; }

    private void Awake()
    {
        instance = this;

        Player = FindObjectOfType<Player>();
        EnemyManager = FindObjectOfType<EnemyManager>();
    }
}