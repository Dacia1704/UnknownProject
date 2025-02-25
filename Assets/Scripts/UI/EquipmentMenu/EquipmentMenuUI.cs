using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EquipmentMenuUI : UIBase {
    public event Action<List<EquipmentData>> OnInventoryChanged;
    
    public event Action<List<InventoryItemUI>> OnEquipmentChanged; 
    
    [HideInInspector] public InventoryUI InventoryUI;
    [HideInInspector] public PlayerEquipmentUI PlayerEquipmentUI;
    [HideInInspector] public PlayerStats baseStats;
    [HideInInspector] public PlayerStats PlayerStats;
         

    [SerializeField] private Button closeButton;

    private void Awake()
    {
        InventoryUI = GetComponentInChildren<InventoryUI>();
        PlayerEquipmentUI = GetComponentInChildren<PlayerEquipmentUI>();
    }

    protected void Start()
    {
        
        closeButton.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlayButtonAudio(UIManager.Instance.UIAudioSource);
            Disable();
        });
        Disable();

        

        OnInventoryChanged += InventoryUI.UpdateInventory;
        OnEquipmentChanged += PlayerEquipmentUI.SetPlayerStatsWithEquipment;
    }
    
    public void SetBasePlayerStats(PlayerStats playerStats)
    {
        baseStats = playerStats;
        UpdatePlayerStats();
    }

    public void UpdatePlayerStats()
    {
        OnEquipmentChanged?.Invoke(PlayerEquipmentUI.ListEquippedItems);
    }

    public void UpdateInventoryUI(List<EquipmentData> equipmentData)
    {
        OnInventoryChanged?.Invoke(equipmentData);
    }
    
    
    


    
}