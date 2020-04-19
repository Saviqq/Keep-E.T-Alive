using UnityEngine;

public abstract class Need : MonoBehaviour
{

    public int healthDamage = 5;

    protected Rigidbody2D rBody;
    protected NeedsLoop needsLoop;
    protected NeedsLifecycle needsLifecycle;

    private void Start()
    {
        SetPosition();
        rBody = GetComponent<Rigidbody2D>();
        needsLoop = GetComponentInParent<NeedsLoop>();
        needsLifecycle = GetComponentInParent<NeedsLifecycle>();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void OnNeedNotSatisfied()
    {
        needsLifecycle.RemoveNeed(tag, true);
    }

    public void OnNeedSatisfied()
    {
        needsLifecycle.RemoveNeed(tag);
    }

    protected abstract void SetPosition();
}
