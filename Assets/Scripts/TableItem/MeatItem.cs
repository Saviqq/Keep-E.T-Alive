using UnityEngine;

public class MeatItem : TableItem
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        onETPartEnter(other);
    }
}
