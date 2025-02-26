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
    
    public int CurrentScore { get; set; }
    public int CurrentWave { get; set; }

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
        if (Input.GetKeyDown(KeyCode.J))
        {
            GameSceneManager.Instance.LoadScene(GameSceneManager.Instance.LeafSceneName);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SaveLoadManager.Instance.SaveToScriptableObject();
            Debug.Log("Save");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            int score;
            int wave;
            List<EquipmentData> equipmentDataList;
            List<EquipmentData> inventoryItemList;
            SaveLoadManager.Instance.LoadFromScriptableObject(out score,out wave,out equipmentDataList,out inventoryItemList);
            CurrentScore = score;
            CurrentWave = wave;
            EquipmentManager.Instance.SetInventoryItemsList(inventoryItemList);
            UIManager.Instance.EquipmentMenuUI.PlayerEquipmentUI.UpdateListEquippedItemsFromListEquipped(equipmentDataList);
        }
        
    }

    public void IncreaseScore(int amount)
    {
        CurrentScore += amount;
        OnPointChange?.Invoke(CurrentScore.ToString());
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        OnPointChange?.Invoke(CurrentScore.ToString());
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