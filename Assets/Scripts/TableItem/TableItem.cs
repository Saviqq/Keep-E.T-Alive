using UnityEngine;

[RequireComponent(typeof(Collider2D)), RequireComponent(typeof(DragItem))]
public class TableItem : MonoBehaviour
{
    private Vector3 defaultPosition;
    private DragItem dragItem;

    private void Start()
    {
        dragItem = this.GetComponent<DragItem>();

        defaultPosition = transform.position;
    }

    protected void onETPartEnter(Collider2D other)
    {
        if (other.tag.Equals(tag))
        {
            dragItem.isDraggable = false;
        }
    }

}
