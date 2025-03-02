using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class GameData
{
    public int HighestScore;
    public int HighestWave; 
    public float GlobalAudioVolume;
    public float BMGAudioVolume;
    public float SFXAudioVolume;
}

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance;
    public GameDataSO GameDataSO;
    private string savePath;
    
    public GameData GameData { get; private set; }
    [HideInInspector] public int CurrentWave;
    [HideInInspector] public int CurrentScore;

    
    public event Action<GameData> OnGameDataLoaded;
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
        DontDestroyOnLoad(this.gameObject);

        CurrentWave = 0;
        CurrentScore = 0;
        savePath = Path.Combine(Application.persistentDataPath, "game_data.json");
        
    }

    private void Start()
    {
        if (CheckFileSave())
        {
            LoadFromJson();
        }
        else
        {
            GameData = new GameData
            {
                HighestScore = 0,
                HighestWave = 0,
                GlobalAudioVolume = 1,
                BMGAudioVolume = 1,
                SFXAudioVolume = 1
            };
            SaveToJson();
        }
        OnGameDataLoaded?.Invoke(GameData);
    }

    public void SaveToScriptableObject()
    {
        GameDataSO.CurrentScore = CurrentScore;
        GameDataSO.CurrentWave = CurrentWave;
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

    private bool CheckFileSave()
    {
        if (File.Exists(savePath))
        {
            return true;
        }

        return false;
    }
    public void SaveToJson()
    {
        GameData data = new GameData()
        {
            HighestWave = CurrentWave,
            HighestScore = CurrentScore,
            GlobalAudioVolume = AudioManager.Instance.GetMasterVolumn(),
            BMGAudioVolume = AudioManager.Instance.GetBGMVolum(),
            SFXAudioVolume = AudioManager.Instance.GetSFXVolum(),
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
            GameData = new GameData
            {
                HighestWave = data.HighestWave,
                HighestScore = data.HighestScore,
                GlobalAudioVolume = data.GlobalAudioVolume,
                BMGAudioVolume = data.BMGAudioVolume,
                SFXAudioVolume = data.SFXAudioVolume
            };
        }
    }

    private void OnApplicationQuit()
    {
        SaveToJson();
    }

    public void LoadDataVolumnToSave(float flobal, float bgm, float sfx)
    {
        GameData.GlobalAudioVolume = flobal;
        GameData.BMGAudioVolume = bgm;
        GameData.SFXAudioVolume = sfx;
        SaveToJson();
    }
}