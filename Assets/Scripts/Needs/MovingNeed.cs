using UnityEngine;

public class MovingNeed : Need
{

    public Vector3 startPosition;
    public Vector3 endPosition;

    protected float distance;

    protected override void SetPosition()
    {
        transform.position = startPosition;
        distance = Vector3.Distance(startPosition, endPosition);
    }

    private void FixedUpdate()
    {
        if (transform.position.x >= endPosition.x)
        {
            OnNeedNotSatisfied();
        }
        rBody.MovePosition(transform.position + transform.right * Time.deltaTime * (distance / needsLoop.currentSecUntilNeedActive));
    }
}
