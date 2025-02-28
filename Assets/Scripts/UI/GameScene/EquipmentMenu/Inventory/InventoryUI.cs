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
                for (int i = contentInventory.childCount - 1; i >= 0; i--)
                {
                        Transform child = contentInventory.GetChild(i);
                        InventorySlotUIObjectPooling.ReleaseObject(child.gameObject);
                }
                foreach (EquipmentData data in dataList)
                {
                        GameObject slot =  InventorySlotUIObjectPooling.GetObject("InventorySlotUI");
                        slot.transform.SetParent(contentInventory);
                        slot.transform.SetAsLastSibling();
                        
                        InventoryItemUI inventoryItemUI = slot.GetComponentInChildren<InventoryItemUI>();
                        inventoryItemUI.EquipmentData = new EquipmentData(data.EquipmentPropsSO,data.EquipmentStats);
                }
        }

        public void UpdateInventoryItemsList()
        {
                List<EquipmentData> dataList = new List<EquipmentData>();
                foreach (Transform child in contentInventory)
                {
                        dataList.Add(child.GetComponentInChildren<InventoryItemUI>().EquipmentData);
                }
                EquipmentManager.Instance.SetInventoryItemsList(dataList);
        }
}