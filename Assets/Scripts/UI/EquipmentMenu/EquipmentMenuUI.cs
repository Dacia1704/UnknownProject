using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentMenuUI : UIBase {
    public event Action<List<EquipmentData>> OnInventoryChanged;
    
    public event Action<PlayerStats> OnPlayerStatsUpdated;
    
    private PlayerStatsUI playerStatsUI;
    private InventoryUI inventoryUI;
         

    [SerializeField] private Button CloseButton;
    protected void Start()
    {
        
        CloseButton.onClick.AddListener(() => Hide());
        Hide();

        inventoryUI = GetComponentInChildren<InventoryUI>();
        playerStatsUI = GetComponentInChildren<PlayerStatsUI>();

        OnPlayerStatsUpdated += playerStatsUI.UpdateStatsText;
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