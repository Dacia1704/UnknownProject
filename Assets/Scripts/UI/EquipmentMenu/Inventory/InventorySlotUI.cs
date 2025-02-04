using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : DropItem
{
    [field: SerializeField]public InventoryItemUI InventoryItemUI { get; private set; }

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
        // base.OnDrop(eventData);
        GameObject droppedObject = eventData.pointerDrag;
        DraggableItem draggableItem = droppedObject.GetComponent<DraggableItem>();
        Transform parentToSwap = draggableItem.ParentPreDrag;
        this.InventoryItemUI.ChangeDropItem(parentToSwap);
        draggableItem.ParentAfterDrag = transform;
        InventoryItemUI = eventData.pointerDrag.GetComponent<InventoryItemUI>();
        
    }
    
    
}