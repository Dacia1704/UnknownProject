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
}