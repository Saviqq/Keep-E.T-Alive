using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ETPart : MonoBehaviour
{

    public NeedsLifecycle needsLifecycle;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals(tag))
        {
            PlaySoundEffect();
            needsLifecycle.RemoveNeed(tag);
        }
    }

    private void PlaySoundEffect()
    {
        AudioSource soundEffect = gameObject.GetComponent<AudioSource>();
        soundEffect.Play();
    }
}
