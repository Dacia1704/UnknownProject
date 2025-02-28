using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class GameData
{
    public int HighestScore;
    public int HighestWave;
}

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance;
    public GameDataSO GameDataSO;
    private string savePath;
    
    public GameData GameData { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        savePath = Path.Combine(Application.persistentDataPath, "game_data.json");
    }

    public void SaveToScriptableObject()
    {
        GameDataSO.CurrentScore = GameManager.Instance.CurrentScore;
        GameDataSO.CurrentWave = GameManager.Instance.CurrentWave;
        GameDataSO.InventoryList = new List<EquipmentData>(EquipmentManager.Instance.InventoryItems);
        GameDataSO.EquipmentList = new List<EquipmentData>();
        foreach (InventoryItemUI item in GameSceneUIManager.Instance.EquipmentMenuUI.PlayerEquipmentUI.ListEquippedItems)
        {
            GameDataSO.EquipmentList.Add(item.EquipmentData);
        }

    }

    public void LoadFromScriptableObject(out int score,out int wave, out List<EquipmentData> equipmentList,out List<EquipmentData> inventoryList)
    {
        score = GameDataSO.CurrentScore;
        wave = GameDataSO.CurrentWave;
        equipmentList = new List<EquipmentData>(GameDataSO.EquipmentList);
        inventoryList = new List<EquipmentData>(GameDataSO.InventoryList);
    }

    public void SaveToJson()
    {
        GameData data = new GameData()
        {
            HighestWave = GameManager.Instance.CurrentWave,
            HighestScore = GameManager.Instance.CurrentScore
        };
        
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
    }

    public void LoadFromJson()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            
            GameData.HighestWave = data.HighestWave;
            GameData.HighestScore = data.HighestScore;
        }
    }

    private void OnApplicationQuit()
    {
        SaveToJson();
    }
}