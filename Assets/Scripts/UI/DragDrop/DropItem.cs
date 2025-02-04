using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour,IDropHandler {
    private DraggableItem currentDraggableItem;
    public virtual void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        DraggableItem dragItem = droppedObject.GetComponent<DraggableItem>();
        
        // Debug.Log(gameObject.name +" " + droppedObject.name);
        dragItem.ParentAfterDrag = transform;
        
        
    }
}