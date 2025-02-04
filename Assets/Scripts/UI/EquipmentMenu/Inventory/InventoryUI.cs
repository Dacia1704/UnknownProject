using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI: MonoBehaviour
{
        private InventorySlotUIObjectPooling inventorySlotUIObjectPooling;

        [SerializeField] private Transform contentInventory;

        public PreviewEquimentStatsUI PreviewEquimentStatsUI { get; private set; }

        private void Awake()
        {
                inventorySlotUIObjectPooling = GetComponentInChildren<InventorySlotUIObjectPooling>();
                
                PreviewEquimentStatsUI = transform.parent.GetComponentInChildren<PreviewEquimentStatsUI>();
        }

        public void UpdateInventory(List<EquipmentData> dataList)
        {
                foreach (Transform child in contentInventory)
                {
                        inventorySlotUIObjectPooling.ReleaseObject(transform.gameObject);
                }
                foreach (EquipmentData data in dataList)
                {
                        GameObject slot =  inventorySlotUIObjectPooling.GetObject("InventorySlotUI");
                        slot.transform.SetParent(contentInventory);
                        slot.transform.SetAsLastSibling();
                        
                        InventoryItemUI inventoryItemUI = slot.GetComponentInChildren<InventoryItemUI>();
                        inventoryItemUI.EquipmentData = data;


                }
        }
}