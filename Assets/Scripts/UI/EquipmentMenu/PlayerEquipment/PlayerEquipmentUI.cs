using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEquipmentUI : MonoBehaviour
{
    
    public PlayerStatsUI PlayerStatsUI { get; private set; }
    public PreviewEquimentStatsUI PreviewEquimentStatsUI { get; private set; }
    [SerializeField] private TextMeshProUGUI equipmentSetText;
    
    [field: SerializeField] public List<InventoryItemUI> ListEquippedItems { get; private set; }
    private EquipmentMenuUI equipmentMenuUI;

    private int countPrimordialSets;
    private int countGuardianSets;
    private int countElementalSets;
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
            if (child?.GetComponentInChildren<InventoryItemUI>())
            {
                ListEquippedItems.Add(child.GetComponentInChildren<InventoryItemUI>());            
            }
        }
        UpdateCountEquipmentSet(ListEquippedItems);
        equipmentMenuUI.UpdatePlayerStats();
    }

    public void SetPlayerStatsWithEquipment()
    {
        PlayerStats playerStats = new PlayerStats(equipmentMenuUI.baseStats);
        
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
                if ( item.EquipmentData.EquipmentStats.CanDealDebuffEffects.Count >0 &&!playerStats.CanDealDebuffEffects.Contains(item.EquipmentData.EquipmentStats.CanDealDebuffEffects[0]) && item.EquipmentData.EquipmentStats.CanDealDebuffEffects[0] != DebuffEffect.None)
                {
                    playerStats.CanDealDebuffEffects.Add(item.EquipmentData.EquipmentStats.CanDealDebuffEffects[0]);
                }
            }
        }
        PlayerStats setBonusStats = new PlayerStats();
        setBonusStats.Attack += (int)(playerStats.Attack * 0.15 * countPrimordialSets);
        setBonusStats.Defend += (int)(playerStats.Defend * 0.1 * countGuardianSets);
        setBonusStats.Health += (int)(playerStats.Health * 0.15 * countGuardianSets);
        setBonusStats.Accuracy += (int)(0.4 * countElementalSets);
        setBonusStats.Resistance += (int)(0.4 * countElementalSets);

        equipmentMenuUI.PlayerStats = new PlayerStats(playerStats,setBonusStats);
        
        GameManager.instance.Player.SetPlayerStats(playerStats);
        PlayerStatsUI.UpdateStatsText(equipmentMenuUI.PlayerStats);
    }

    private void UpdateCountEquipmentSet(List<InventoryItemUI> equipmentItems)
    {
        int countPrimordialItems = 0;
        int countGuardianItems = 0;
        int countElementalItems = 0;
        foreach (InventoryItemUI item in equipmentItems)
        {
            if (item.EquipmentData?.EquipmentPropsSO.EquipmentSet == EquipmentSet.Primordial)
            {
                countPrimordialItems += 1;
            }else if (item.EquipmentData?.EquipmentPropsSO.EquipmentSet == EquipmentSet.Guardian)
            {
                countGuardianItems += 1;
            }
            else
            {
                countElementalItems += 1;
            }
        }

        countPrimordialSets = countPrimordialItems / 4;
        countGuardianSets = countGuardianItems / 2;
        countElementalSets = countElementalItems / 4;

        string setText = "";
        if (countPrimordialSets > 0) setText += "Set 4: Primordial Set (+15% Atk) \n";
        if (countGuardianSets >0) setText += "Set 2: Guardian Set (+10% Hp & Def) \n";
        if (countElementalSets>0) setText += "Set4: Elemental Set (+40% Acc & Res) \n";
        equipmentSetText.text = setText;
    }
}
