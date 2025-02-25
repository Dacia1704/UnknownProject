using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameDataSO", menuName = "GameDataSO")]
public class GameDataSO : ScriptableObject
{
    public int CurrentScore;
    public int CurrentWave;

    [field: Header("Player")] 
    [field: SerializeField] public List<EquipmentData> InventoryList;
    [field: SerializeField] public List<EquipmentData> EquipmentList;
}