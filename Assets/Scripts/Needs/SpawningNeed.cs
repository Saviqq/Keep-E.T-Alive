using UnityEngine;

public abstract class SpawningNeed : Need
{

    public Vector3[] spawnPosition;

    private float spawnDuration;

    private void Update()
    {
        spawnDuration += Time.deltaTime;

        if (spawnDuration >= needsLoop.currentSecUntilNeedActive)
        {
            OnNeedNotSatisfied();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals(tag))
        {
            OnNeedSatisfied();
        }
    }

    protected override void SetPosition()
    {
        transform.position = spawnPosition[Random.Range(0, spawnPosition.Length)];
    }


}
