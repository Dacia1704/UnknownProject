using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI: MonoBehaviour
{
        public InventorySlotUIObjectPooling InventorySlotUIObjectPooling { get; private set; }

        [SerializeField] private Transform contentInventory;

        public PreviewEquimentStatsUI PreviewEquimentStatsUI { get; private set; }

        private void Awake()
        {
                InventorySlotUIObjectPooling = GetComponentInChildren<InventorySlotUIObjectPooling>();
                
                PreviewEquimentStatsUI = transform.parent.GetComponentInChildren<PreviewEquimentStatsUI>();
        }

        public void UpdateInventory(List<EquipmentData> dataList)
        {
                foreach (Transform child in contentInventory)
                {
                        InventorySlotUIObjectPooling.ReleaseObject(child.gameObject);
                }
                foreach (EquipmentData data in dataList)
                {
                        GameObject slot =  InventorySlotUIObjectPooling.GetObject("InventorySlotUI");
                        slot.transform.SetParent(contentInventory);
                        slot.transform.SetAsLastSibling();
                        
                        InventoryItemUI inventoryItemUI = slot.GetComponentInChildren<InventoryItemUI>();
                        inventoryItemUI.EquipmentData = data;


                }
        }
}