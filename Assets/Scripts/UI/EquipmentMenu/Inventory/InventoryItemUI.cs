using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemUI : DraggableItem,IPointerClickHandler
{
    public EquipmentData EquipmentData;

    private Image image;
    
    private void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(UpdateImageIcon());
        
    }

    private IEnumerator UpdateImageIcon()
    {
        yield return new WaitUntil(() => EquipmentData != null);
        
        if (EquipmentData?.EquipmentPropsSO.SpriteItem)
        {
            image.sprite = EquipmentData.EquipmentPropsSO.SpriteItem;
            Color newColor = image.color;
            newColor.a = 1.0f;
            image.color = newColor;
        }
        else
        {
            Color newColor = image.color;
            newColor.a = 0f;
            image.color = newColor;
        }
    }
    private void UpdatePreviewEquipmentStats()
    {
        
        InventoryUI inventoryUI = GetComponentInParent<InventoryUI>();
        PlayerEquipmentUI playerEquipmentUI = GetComponentInParent<PlayerEquipmentUI>();
        if (inventoryUI != null)
        {
            inventoryUI.PreviewEquimentStatsUI.Enable();
            inventoryUI.PreviewEquimentStatsUI.SetEquipmentData(EquipmentData);
        }
        else
        {
            playerEquipmentUI.PreviewEquimentStatsUI.Enable();
            playerEquipmentUI.PreviewEquimentStatsUI.SetEquipmentData(EquipmentData);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UpdatePreviewEquipmentStats();
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        AudioManager.Instance.PlayBeginDragAudio(UIManager.Instance.UIAudioSource);
        base.OnBeginDrag(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        AudioManager.Instance.PlayEndDragAudio(UIManager.Instance.UIAudioSource);
        base.OnEndDrag(eventData);
        
        if (transform?.GetComponentInParent<PlayerEquipmentSlotUI>())
        {
            GetComponentInParent<PlayerEquipmentSlotUI>().PlayerEquipmentUI.UpdateListEquippedItems();
        }
    }
}