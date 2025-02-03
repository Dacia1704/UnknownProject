using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour,IDropHandler {
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        DraggableItem draggableItem = droppedObject.GetComponent<DraggableItem>();
        
        Debug.Log(gameObject.name +" " + droppedObject.name);
        draggableItem.ParentAfterDrag = transform;
        //
        // var canvas = draggableItem.IconImage.canvas;
        // position.z = canvas.planeDistance;
        // IconImage.transform.position = canvas.worldCamera.ScreenToWorldPoint(position);
    }
}