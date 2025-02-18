using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreviewEquimentStatsUI : UIBase
{
    private EquipmentData equipmentData;
    [SerializeField] private Image imageIcon;
    [SerializeField] private TextMeshProUGUI mainStat;
    [SerializeField] private TextMeshProUGUI subStats;
    
    [SerializeField] private Button CloseButton;

    private void Start()
    {
        CloseButton.onClick.AddListener(() => Disable());
        Disable();
    }


    public void SetEquipmentData(EquipmentData equipmentData)
    {
        this.equipmentData = equipmentData;
        UpdateStats();
    }

    private void UpdateStats()
    {
        imageIcon.sprite = equipmentData.EquipmentPropsSO.SpriteItem;

        if (equipmentData.EquipmentPropsSO.EquimentType == EquimentType.Armor)
        {
            mainStat.text = "Def: " + equipmentData.EquipmentStats.Defend.ToString();

            string subText = "";
            if(equipmentData.EquipmentStats.Speed !=0 ) subText = subText + "Spd: " +  equipmentData.EquipmentStats.Speed.ToString() + "\n";
            if(equipmentData.EquipmentStats.Attack != 0) subText = subText + "Atk: " + equipmentData.EquipmentStats.Attack.ToString() + "\n";
            if(equipmentData.EquipmentStats.Health != 0) subText = subText + "Hp: "+ equipmentData.EquipmentStats.Health.ToString() + "\n";
            if(equipmentData.EquipmentStats.AttackSpeed != 0) subText = subText +"AtkSpd: " + equipmentData.EquipmentStats.AttackSpeed.ToString("F2") + "\n";
            if(equipmentData.EquipmentStats.Resistance != 0) subText = subText +"Res: " + equipmentData.EquipmentStats.Resistance.ToString("F2") + "\n";
            if(equipmentData.EquipmentStats.Accuracy != 0) subText = subText +"Acc: " + equipmentData.EquipmentStats.Accuracy.ToString("F2") + "\n";
            if(equipmentData.EquipmentStats.CanDealDebuffEffects[0] != DebuffEffect.None) subText = subText + "Effect: " + equipmentData.EquipmentStats.CanDealDebuffEffects[0].ToString() + "\n";
            subStats.text = subText;
        }
        else if (equipmentData.EquipmentPropsSO.EquimentType == EquimentType.Necklace)
        {
            mainStat.text ="Hp: "  +equipmentData.EquipmentStats.Health.ToString();
            
            string subText = "";
            if(equipmentData.EquipmentStats.Speed !=0 ) subText = subText +"Spd: " +  equipmentData.EquipmentStats.Speed.ToString() + "\n";
            if(equipmentData.EquipmentStats.Attack != 0) subText = subText + "Atk: " + equipmentData.EquipmentStats.Attack.ToString() + "\n";
            if(equipmentData.EquipmentStats.Defend != 0) subText = subText +"Def: " + equipmentData.EquipmentStats.Defend.ToString() + "\n";
            if(equipmentData.EquipmentStats.AttackSpeed != 0) subText = subText +"AtkSpd: " +  equipmentData.EquipmentStats.AttackSpeed.ToString("F2") + "\n";
            if(equipmentData.EquipmentStats.Resistance != 0) subText = subText +"Res: " +  equipmentData.EquipmentStats.Resistance.ToString("F2") + "\n";
            if(equipmentData.EquipmentStats.Accuracy != 0) subText = subText +"Acc: " +  equipmentData.EquipmentStats.Accuracy.ToString("F2") + "\n";
            if(equipmentData.EquipmentStats.CanDealDebuffEffects[0] != DebuffEffect.None) subText = subText + "Effect: " + equipmentData.EquipmentStats.CanDealDebuffEffects[0].ToString() + "\n";
            subStats.text = subText;
        }
        else if (equipmentData.EquipmentPropsSO.EquimentType == EquimentType.Weapon)
        {
            mainStat.text = "Atk: " + equipmentData.EquipmentStats.Attack.ToString();
            
            string subText = "";
            if(equipmentData.EquipmentStats.Speed !=0 ) subText = subText +"Spd: " +  equipmentData.EquipmentStats.Speed.ToString() + "\n";
            if(equipmentData.EquipmentStats.Health != 0) subText = subText + "Hp: " + equipmentData.EquipmentStats.Health.ToString() + "\n";
            if(equipmentData.EquipmentStats.Defend != 0) subText = subText + "Def: " + equipmentData.EquipmentStats.Defend.ToString() + "\n";
            if(equipmentData.EquipmentStats.AttackSpeed != 0) subText = subText + "AtkSpd: " + equipmentData.EquipmentStats.AttackSpeed.ToString("F2") + "\n";
            if(equipmentData.EquipmentStats.Resistance != 0) subText = subText + "Res: " + equipmentData.EquipmentStats.Resistance.ToString("F2") + "\n";
            if(equipmentData.EquipmentStats.Accuracy != 0) subText = subText + "Acc: " + equipmentData.EquipmentStats.Accuracy.ToString("F2") + "\n";
            if(equipmentData.EquipmentStats.CanDealDebuffEffects[0] != DebuffEffect.None) subText = subText + "Effect: " + equipmentData.EquipmentStats.CanDealDebuffEffects[0].ToString() + "\n";
            subStats.text = subText;
        }
        else if (equipmentData.EquipmentPropsSO.EquimentType == EquimentType.Boots)
        {
            mainStat.text = "Spd: " + equipmentData.EquipmentStats.Speed.ToString();
            
            string subText = "";
            if(equipmentData.EquipmentStats.Attack !=0 ) subText = subText + "Atk: " + equipmentData.EquipmentStats.Attack.ToString() + "\n";
            if(equipmentData.EquipmentStats.Health != 0) subText = subText + "Hp: " + equipmentData.EquipmentStats.Health.ToString() + "\n";
            if(equipmentData.EquipmentStats.Defend != 0) subText = subText + "Def: " + equipmentData.EquipmentStats.Defend.ToString() + "\n";
            if(equipmentData.EquipmentStats.AttackSpeed != 0) subText = subText +"AtkSpd: " + equipmentData.EquipmentStats.AttackSpeed.ToString("F2") + "\n";
            if(equipmentData.EquipmentStats.Resistance != 0) subText = subText + "Res: " + equipmentData.EquipmentStats.Resistance.ToString("F2") + "\n";
            if(equipmentData.EquipmentStats.Accuracy != 0) subText = subText +"Acc: " + equipmentData.EquipmentStats.Accuracy.ToString("F2") + "\n";
            if(equipmentData.EquipmentStats.CanDealDebuffEffects[0] != DebuffEffect.None) subText = subText + "Effect: " + equipmentData.EquipmentStats.CanDealDebuffEffects[0].ToString() + "\n";
            subStats.text = subText;
        }
        else
        {
            if(equipmentData.EquipmentStats.AttackSpeed > 2.0f) 
                mainStat.text = "AtkSpd: " + equipmentData.EquipmentStats.AttackSpeed.ToString("F2");
            else if(equipmentData.EquipmentStats.Resistance > 0.4f) 
                mainStat.text = "Res: " +equipmentData.EquipmentStats.Resistance.ToString("F2");
            else if(equipmentData.EquipmentStats.Accuracy > 0.4f) 
                mainStat.text = "Acc: " + equipmentData.EquipmentStats.Accuracy.ToString("F2");
            
            string subText = "";
            if(equipmentData.EquipmentStats.Speed !=0 ) subText = subText + "Spd: " + equipmentData.EquipmentStats.Speed.ToString() + "\n";
            if(equipmentData.EquipmentStats.Attack !=0 ) subText = subText +"Atk: " +  equipmentData.EquipmentStats.Attack.ToString() + "\n";
            if(equipmentData.EquipmentStats.Health != 0) subText = subText + "Hp: " +equipmentData.EquipmentStats.Health.ToString() + "\n";
            if(equipmentData.EquipmentStats.Defend != 0) subText = subText + "Def: " + equipmentData.EquipmentStats.Defend.ToString() + "\n";
            if(equipmentData.EquipmentStats.AttackSpeed != 0 && equipmentData.EquipmentStats.AttackSpeed<=1.01f) subText = subText +"AtkSpd: " + equipmentData.EquipmentStats.AttackSpeed.ToString("F2") + "\n";
            if(equipmentData.EquipmentStats.Resistance != 0 && equipmentData.EquipmentStats.Resistance <= 0.2f) subText = subText + "Res: " +equipmentData.EquipmentStats.Resistance.ToString("F2") + "\n";
            if(equipmentData.EquipmentStats.Accuracy != 0 && equipmentData.EquipmentStats.Accuracy <= 0.2f) subText = subText +"Acc: " + equipmentData.EquipmentStats.Accuracy.ToString("F2") + "\n";
            if(equipmentData.EquipmentStats.CanDealDebuffEffects[0] != DebuffEffect.None) subText = subText + "Effect: " + equipmentData.EquipmentStats.CanDealDebuffEffects[0].ToString() + "\n";
            subStats.text = subText;
        }

    }
}
