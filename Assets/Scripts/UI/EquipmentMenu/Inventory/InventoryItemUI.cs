using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemUI : DraggableItem,IPointerClickHandler
{
    public EquipmentData EquipmentData;

    private Image image;
    
    private InventoryUI inventoryUI;
    
    


    private void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(UpdateImageIcon());
        
        inventoryUI = GetComponentInParent<InventoryUI>();
    }

    private IEnumerator UpdateImageIcon()
    {
        yield return new WaitUntil(() => EquipmentData != null);
        image.sprite = EquipmentData?.EquipmentPropsSO.SpriteItem;
    }
    private void UpdatePreviewEquipmentStats()
    {
        inventoryUI.PreviewEquimentStatsUI.Show();
        inventoryUI.PreviewEquimentStatsUI.SetEquipmentData(EquipmentData);
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(1);
        UpdatePreviewEquipmentStats();
    }
}