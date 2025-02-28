using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour,IDropHandler
{
    public virtual void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        DraggableItem dragItem = droppedObject.GetComponent<DraggableItem>();
        dragItem.ParentAfterDrag = transform;
    }
}