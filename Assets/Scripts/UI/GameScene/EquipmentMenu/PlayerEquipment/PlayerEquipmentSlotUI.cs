using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerEquipmentSlotUI:  DropItem
{
        [field: SerializeField]public EquimentType EquimentType { get; private set; }
        
        [HideInInspector] public PlayerEquipmentUI PlayerEquipmentUI;

        [HideInInspector] public InventoryItemUI InventoryItemUI;


        private void Start()
        {
                PlayerEquipmentUI = GetComponentInParent<PlayerEquipmentUI>();
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
                
                DraggableItem draggableItem = droppedObject.GetComponent<DraggableItem>();
                Transform parentToSwap = draggableItem.ParentPreDrag;
                this.InventoryItemUI.ChangeDropItem(parentToSwap);
                if(parentToSwap.TryGetComponent(out PlayerEquipmentSlotUI playerEquipmentSlotUI))
                {
                        parentToSwap.GetComponent<PlayerEquipmentSlotUI>().InventoryItemUI = this.InventoryItemUI;
                }
                else
                {
                        parentToSwap.GetComponent<InventorySlotUI>().InventoryItemUI = this.InventoryItemUI;
                        if (parentToSwap.GetComponent<InventorySlotUI>().InventoryItemUI.EquipmentData.EquipmentPropsSO == null)
                        {
                                parentToSwap.GetComponentInParent<InventoryUI>().InventorySlotUIObjectPooling.ReleaseObject(parentToSwap.gameObject);
                        }
                }
                draggableItem.ParentAfterDrag = transform;

                InventoryItemUI = temp;
                
                GameSceneUIManager.Instance.EquipmentMenuUI.InventoryUI.UpdateInventoryItemsList();


        }
}