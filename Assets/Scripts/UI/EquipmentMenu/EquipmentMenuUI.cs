using System;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentMenuUI : UIBase {
    // public event Action<InventoryItem> OnInventoryChanged;
    
    public event Action<PlayerStats> OnPlayerStatsUpdated;
    
    private PlayerStatsUI playerStatsUI;
         

    [SerializeField] private Button CloseButton;
    protected void Start()
    {
        
        CloseButton.onClick.AddListener(() => Hide());
        Hide();

        playerStatsUI = GetComponentInChildren<PlayerStatsUI>();

        OnPlayerStatsUpdated += playerStatsUI.UpdateStatsText;
    }
    
    public void UpdatePlayerStats(PlayerStats playerStats)
    {
        OnPlayerStatsUpdated?.Invoke(playerStats);
    }

    
}