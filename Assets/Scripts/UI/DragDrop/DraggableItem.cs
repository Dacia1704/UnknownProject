using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class DraggableItem : MonoBehaviour,IBeginDragHandler,IDragHandler, IEndDragHandler
{
    [HideInInspector]public Image IconImage;
    [HideInInspector]public Transform ParentPreDrag;
    [HideInInspector]public Transform ParentAfterDrag;
    
    protected virtual void OnEnable()
    {
        IconImage = GetComponent<Image>();
        ParentPreDrag = transform.parent;
    }
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("OnBeginDrag");
        ParentPreDrag = transform.parent;
        ParentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        IconImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("OnDrag");
        Vector3 position = eventData.position;
        var canvas = IconImage.canvas;
        position.z = canvas.planeDistance;
        IconImage.transform.position = canvas.worldCamera.ScreenToWorldPoint(position);
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        ChangeDropItem(ParentAfterDrag);
        IconImage.raycastTarget = true;
    }

    public void ChangeDropItem(Transform newParent)
    {
        transform.SetParent(newParent);
        Vector3 position = new Vector3(0, 0, IconImage.canvas.planeDistance);
        IconImage.rectTransform.localPosition = position;
        transform.SetAsLastSibling();
    }

}
