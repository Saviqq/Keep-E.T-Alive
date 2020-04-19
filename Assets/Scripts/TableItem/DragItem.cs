using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DragItem : MonoBehaviour
{

    public bool isDraggable = true;

    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 defaultPosition;

    private void Start()
    {
        defaultPosition = transform.position;
    }

    private void OnMouseDown()
    {
        isDraggable = true;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4f));
    }

    private void OnMouseUp()
    {
        isDraggable = true;
        MoveToDefaultPosition();
    }

    private void OnMouseDrag()
    {
        if (isDraggable)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4f);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            transform.position = new Vector3(currentPosition.x, currentPosition.y, 4f);
        }
        else
        {
            MoveToDefaultPosition();
        }

    }

    private void MoveToDefaultPosition()
    {
        float dist = Vector3.Distance(transform.position, defaultPosition);
        float duration = 5f / dist;
        iTween.MoveTo(gameObject, iTween.Hash("position", defaultPosition, "duration", duration));
    }

}
