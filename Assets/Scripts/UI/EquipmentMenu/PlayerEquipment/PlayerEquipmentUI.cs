using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentUI : MonoBehaviour
{
    public PlayerStatsUI PlayerStatsUI { get; private set; }
    public PreviewEquimentStatsUI PreviewEquimentStatsUI { get; private set; }
    
    public List<InventoryItemUI> ListEquippedItems { get; private set; }

    private void Awake()
    {
        PlayerStatsUI = GetComponentInChildren<PlayerStatsUI>();
        PreviewEquimentStatsUI = GetComponentInChildren<PreviewEquimentStatsUI>();
    }

    private void Start()
    {
        ListEquippedItems = new List<InventoryItemUI>();
        foreach (Transform child in transform)
        {
            ListEquippedItems.Add(child.GetComponent<InventoryItemUI>());            
        }
    }
}
