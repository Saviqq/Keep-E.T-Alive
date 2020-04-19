using UnityEngine;

public class BeerItem : TableItem
{

    string BEER_TAG = NeedTags.BEER_TAG.Value;

    private void OnTriggerEnter2D(Collider2D other)
    {
        onETPartEnter(other);
    }
}
