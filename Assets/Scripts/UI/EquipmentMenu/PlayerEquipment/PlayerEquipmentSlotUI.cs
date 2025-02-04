using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerEquipmentSlotUI:  DropItem
{
        [field: SerializeField]public EquimentType EquimentType { get; private set; }
        
        private PlayerEquipmentUI playerEquipmentUI;
        
        [field: SerializeField] public InventoryItemUI InventoryItemUI { get; private set; }


        private void Start()
        {
                playerEquipmentUI = GetComponentInParent<PlayerEquipmentUI>();
                InventoryItemUI = GetComponentInChildren<InventoryItemUI>();
                
        }
        
        public override void OnDrop(PointerEventData eventData)
        {
                GameObject droppedObject = eventData.pointerDrag;
                InventoryItemUI temp = droppedObject.GetComponent<InventoryItemUI>();
                if (temp.EquipmentData.EquipmentPropsSO.EquimentType != this.EquimentType)
                {
                        return;
                }
                
                // base.OnDrop(eventData);
                
                
                DraggableItem draggableItem = droppedObject.GetComponent<DraggableItem>();
                Transform parentToSwap = draggableItem.ParentPreDrag;
                this.InventoryItemUI.ChangeDropItem(parentToSwap);
                draggableItem.ParentAfterDrag = transform;

                InventoryItemUI = temp;


        }
}