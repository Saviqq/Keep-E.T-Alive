
using UnityEngine;

public class PatchItem : TableItem
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals(tag))
        {
            AudioSource soundEffect = gameObject.GetComponent<AudioSource>();
            soundEffect.Play();
        }

        onETPartEnter(other);
    }
}
