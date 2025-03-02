using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [field: SerializeField] private int timeAWave;
    [field: SerializeField] private int timeStartGame;
    private int timeCounter;
    private int timeCounterStartGame;
    
    // public int CurrentScore { get; set; }
    // public int CurrentWave { get; set; }

    public Player Player { get; private set; }
    public EnemyManager EnemyManager { get; private set; }
    public FloatingTextUIObjectPooling FloatingTextUIObjectPooling { get; private set; }
    
    public event Action<string> OnCounterTimeStartGame;
    public event Action<string> OnPointChange;
    public event Action<string> OnCounterTime;

    private void Awake()
    {
        Instance = this;

        Player = FindObjectOfType<Player>();
        EnemyManager = FindObjectOfType<EnemyManager>();
        FloatingTextUIObjectPooling = FindObjectOfType<FloatingTextUIObjectPooling>();
    }

    private void Start()
    {
        timeCounterStartGame = timeStartGame;
        StartCoroutine(CountTimeStartGameCoroutine());
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

    private void Update()
    {
        
    }

    public void IncreaseCurrentScore(int amount)
    {
        SaveLoadManager.Instance.CurrentScore += amount;
        OnPointChange?.Invoke(SaveLoadManager.Instance.CurrentScore.ToString());
    }

    public void ResetCurrentScore()
    {
        SaveLoadManager.Instance.CurrentScore = 0;
        OnPointChange?.Invoke(SaveLoadManager.Instance.CurrentScore.ToString());
    }

    public void StartCountTime()
    {
        timeCounter = timeAWave;
        StartCoroutine(CountTimeCoroutine());
    }

    private IEnumerator CountTimeStartGameCoroutine()
    {
        while (timeCounterStartGame >=0)
        {
            OnCounterTimeStartGame?.Invoke(timeCounterStartGame.ToString());
            yield return new WaitForSeconds(1);
            timeCounterStartGame -= 1;
            if (timeCounterStartGame < 0)
            {
                StartCountTime();
            }
        }
    }

    private IEnumerator CountTimeCoroutine()
    {
        while (timeCounter >= 0)
        {
            OnCounterTime?.Invoke(timeCounter.ToString());
            yield return new WaitForSeconds(1);
            timeCounter -= 1;
        }
    }
}