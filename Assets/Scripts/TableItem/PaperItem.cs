using UnityEngine;

public class PaperItem : TableItem
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        onETPartEnter(other);
    }
}
