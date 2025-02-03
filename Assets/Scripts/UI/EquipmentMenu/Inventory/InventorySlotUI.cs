using System;
using UnityEngine;

public class InventorySlotUI : DropItem
{
        public InventoryItemUI InventoryItemUI { get; private set; }

        private void Start()
        {
                InventoryItemUI = GetComponentInChildren<InventoryItemUI>();
        }
}