using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public int CurrentScore { get; set; }
    public int CurrentWave { get; set; }

    [field: SerializeField]public Player Player { get; private set; }
    [field: SerializeField]public EnemyManager EnemyManager { get; private set; }
    [field: SerializeField]public FloatingTextUIObjectPooling FloatingTextUIObjectPooling { get; private set; }

    private void Awake()
    {
        Instance = this;

        Player = FindObjectOfType<Player>();
        EnemyManager = FindObjectOfType<EnemyManager>();
        FloatingTextUIObjectPooling = FindObjectOfType<FloatingTextUIObjectPooling>();
    }
    
    public void TriggerSlowMotion(float scale,float duration)
    {
        StartCoroutine(SlowMotionCoroutine(scale, duration));
    }

    private IEnumerator SlowMotionCoroutine(float scale,float duration)
    {
        Time.timeScale = scale;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
    }

    
    
}