using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EquipmentMenuUI : UIBase {
    public event Action<List<EquipmentData>> OnInventoryChanged;
    
    public event Action<PlayerStats> OnPlayerStatsUpdated;
    
    private InventoryUI inventoryUI;
    private PlayerEquipmentUI playerEquipmentUI;
         

    [SerializeField] private Button closeButton;
    protected void Start()
    {
        
        closeButton.onClick.AddListener(() => Hide());
        Hide();

        inventoryUI = GetComponentInChildren<InventoryUI>();
        playerEquipmentUI = GetComponentInChildren<PlayerEquipmentUI>();

        OnPlayerStatsUpdated += playerEquipmentUI.PlayerStatsUI.UpdateStatsText;
        OnInventoryChanged += inventoryUI.UpdateInventory;
    }
    
    public void UpdatePlayerStats(PlayerStats playerStats)
    {
        OnPlayerStatsUpdated?.Invoke(playerStats);
    }

    public void UpdateInventoryUI(List<EquipmentData> equipmentData)
    {
        OnInventoryChanged?.Invoke(equipmentData);
    }

    
}