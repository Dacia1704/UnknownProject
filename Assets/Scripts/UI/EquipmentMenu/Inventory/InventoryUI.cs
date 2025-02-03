using System;
using UnityEngine;

public class InventoryUI: MonoBehaviour
{
        private InventorySlotUIObjectPooling inventorySlotUIObjectPooling;

        private void Awake()
        {
                inventorySlotUIObjectPooling = GetComponent<InventorySlotUIObjectPooling>();
        }
}