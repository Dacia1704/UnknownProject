using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentUI : MonoBehaviour
{
    
    public PlayerStatsUI PlayerStatsUI { get; private set; }
    public PreviewEquimentStatsUI PreviewEquimentStatsUI { get; private set; }
    
    [field: SerializeField] public List<InventoryItemUI> ListEquippedItems { get; private set; }
    private EquipmentMenuUI equipmentMenuUI;
    private void Awake()
    {
        PlayerStatsUI = GetComponentInChildren<PlayerStatsUI>();
        PreviewEquimentStatsUI = GetComponentInChildren<PreviewEquimentStatsUI>();
        equipmentMenuUI = GetComponentInParent<EquipmentMenuUI>();
    }

    private void Start()
    {
        ListEquippedItems = new List<InventoryItemUI>();
        UpdateListEquippedItems();
    }

    public void UpdateListEquippedItems()
    {
        ListEquippedItems.Clear();
        foreach (Transform child in transform)
        {
            if(child?.GetComponentInChildren<InventoryItemUI>())
                ListEquippedItems.Add(child.GetComponentInChildren<InventoryItemUI>());            
        }
        
        equipmentMenuUI.UpdatePlayerStats();
    }

    public void SetPlayerStatsWithEquipment()
    {
        PlayerStats playerStats = new PlayerStats(equipmentMenuUI.baseStats);
        // Debug.Log(playerStats);
        foreach (InventoryItemUI item in ListEquippedItems)
        {
            if (item.EquipmentData != null)
            {
                playerStats.Speed += item.EquipmentData.EquipmentStats.Speed;
                playerStats.Health += item.EquipmentData.EquipmentStats.Health;
                playerStats.Defend += item.EquipmentData.EquipmentStats.Defend;
                playerStats.Attack += item.EquipmentData.EquipmentStats.Attack;
                playerStats.AttackSpeed += item.EquipmentData.EquipmentStats.AttackSpeed;
                playerStats.Accuracy += item.EquipmentData.EquipmentStats.Accuracy;
                playerStats.Resistance += item.EquipmentData.EquipmentStats.Resistance;
            }
        }

        equipmentMenuUI.PlayerStats = playerStats;
        
        FindObjectOfType<Player>().SetPlayerStats(playerStats);
        PlayerStatsUI.UpdateStatsText(equipmentMenuUI.PlayerStats);
    }
}
