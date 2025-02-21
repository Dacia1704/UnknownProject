using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EquipmentMenuUI : UIBase {
    public event Action<List<EquipmentData>> OnInventoryChanged;
    
    public event Action<List<InventoryItemUI>> OnEquipmentChanged; 
    
    private InventoryUI inventoryUI;
    public PlayerEquipmentUI playerEquipmentUI;
    [HideInInspector] public PlayerStats baseStats;
    [HideInInspector] public PlayerStats PlayerStats;
         

    [SerializeField] private Button closeButton;
    protected void Start()
    {
        
        closeButton.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlayButtonAudio(UIManager.Instance.UIAudioSource);
            Disable();
        });
        Disable();

        inventoryUI = GetComponentInChildren<InventoryUI>();
        playerEquipmentUI = GetComponentInChildren<PlayerEquipmentUI>();

        OnInventoryChanged += inventoryUI.UpdateInventory;
        OnEquipmentChanged += playerEquipmentUI.SetPlayerStatsWithEquipment;
    }
    
    public void SetBasePlayerStats(PlayerStats playerStats)
    {
        baseStats = playerStats;
        UpdatePlayerStats();
    }

    public void UpdatePlayerStats()
    {
        OnEquipmentChanged?.Invoke(playerEquipmentUI.ListEquippedItems);
    }

    public void UpdateInventoryUI(List<EquipmentData> equipmentData)
    {
        OnInventoryChanged?.Invoke(equipmentData);
    }
    
    
    


    
}