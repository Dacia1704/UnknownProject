using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    
    
    [field: SerializeField] private TextMeshProUGUI speedText ;
    [field: SerializeField] private TextMeshProUGUI attackText ;
    [field: SerializeField] private TextMeshProUGUI healthext ;
    [field: SerializeField] private TextMeshProUGUI defendText ;
    [field: SerializeField] private TextMeshProUGUI attackSpeedText ;
    [field: SerializeField] private TextMeshProUGUI resistanceText ;
    [field: SerializeField] private TextMeshProUGUI accuracyText ;

    public void UpdateStatsText(PlayerStats stats)
    {
        speedText.text = stats.Speed.ToString();
        attackText.text = stats.Attack.ToString();
        healthext.text = stats.Health.ToString();
        defendText.text = stats.Defend.ToString();
        attackSpeedText.text = stats.AttackSpeed.ToString("F2");
        resistanceText.text = stats.Resistance.ToString("F2");
        accuracyText.text = stats.Accuracy.ToString("F2");
    }
}
