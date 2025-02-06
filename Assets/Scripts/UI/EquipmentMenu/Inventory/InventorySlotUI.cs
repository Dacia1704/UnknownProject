using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : DropItem,IPoolingObject
{
    [HideInInspector] public InventoryItemUI InventoryItemUI;
    [field: SerializeField] public PoolingObjectPropsSO PoolingObjectPropsSO { get; set; }

    private void Start()
    {
        StartCoroutine(UpdateInventoryItemUI());
    }
    
    
    private IEnumerator UpdateInventoryItemUI()
    {
        yield return new WaitUntil(() => this?.GetComponentInChildren<InventoryItemUI>());
        
        InventoryItemUI = GetComponentInChildren<InventoryItemUI>();
    }

    public override void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        DraggableItem draggableItem = droppedObject.GetComponent<DraggableItem>();
        Transform parentToSwap = draggableItem.ParentPreDrag;
        this.InventoryItemUI.ChangeDropItem(parentToSwap);
        if (parentToSwap?.GetComponent<PlayerEquipmentSlotUI>())
        {
            parentToSwap.GetComponent<PlayerEquipmentSlotUI>().InventoryItemUI = this.InventoryItemUI;
        }
        else
        {
            parentToSwap.GetComponent<InventorySlotUI>().InventoryItemUI = this.InventoryItemUI;
            if (parentToSwap.GetComponent<InventorySlotUI>().InventoryItemUI.EquipmentData == null)
            {
                parentToSwap.GetComponentInParent<InventoryUI>().InventorySlotUIObjectPooling.ReleaseObject(parentToSwap.gameObject);
            }
        }
        
        draggableItem.ParentAfterDrag = transform;
        InventoryItemUI = eventData.pointerDrag.GetComponent<InventoryItemUI>();
        
    }


    
}