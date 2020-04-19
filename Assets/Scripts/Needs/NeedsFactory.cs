using UnityEngine;

public class NeedsFactory : MonoBehaviour
{

    public MeatNeed meatNeed;
    public BeerNeed beerNeed;
    public PoopNeed poopNeed;
    public BleedNeed bleedNeed;

    private const int NEEDS_COUNT = 4;

    private const int FOOD_NEED = 0;
    private const int BEER_NEED = 1;
    private const int POOP_NEED = 2;
    private const int BLEED_NEED = 3;
    private const int MUSIC_NEED = 4;

    private NeedsLifecycle needsLifecycle;

    void Start()
    {
        needsLifecycle = gameObject.GetComponent<NeedsLifecycle>();
    }

    public void CreateNeed()
    {
        int need = Random.Range(0, NEEDS_COUNT);
        switch (need)
        {
            case FOOD_NEED:
                Debug.Log("E.T needs FOOD!");
                MeatNeed meat = Instantiate(meatNeed);
                meat.transform.parent = gameObject.transform;
                needsLifecycle.AddNeed(meat);
                break;
            case BEER_NEED:
                Debug.Log("E.T needs BEER!");
                BeerNeed beer = Instantiate(beerNeed);
                beer.transform.parent = gameObject.transform;
                needsLifecycle.AddNeed(beer);
                break;
            case POOP_NEED:
                if (needsLifecycle.NeedAlreadySpawned(NeedTags.POOP_TAG.Value))
                {
                    CreateNeed();
                }
                else
                {
                    Debug.Log("E.T pooped!");
                    PoopNeed poop = Instantiate(poopNeed);
                    poop.transform.parent = gameObject.transform;
                    needsLifecycle.AddNeed(poop);
                }
                break;
            case BLEED_NEED:
                if (needsLifecycle.NeedAlreadySpawned(NeedTags.BLEED_TAG.Value))
                {
                    CreateNeed();
                }
                else
                {
                    Debug.Log("E.T is bleeding!");
                    BleedNeed bleed = Instantiate(bleedNeed);
                    bleed.transform.parent = gameObject.transform;
                    needsLifecycle.AddNeed(bleed);
                }
                break;
            case MUSIC_NEED:
                Debug.Log("Toggle music for E.T!");
                break;
            default:
                throw new UnityException();
        }
    }

    public void DestroyAllNeeds()
    {
        needsLifecycle.DestroyAllNeeds();
    }
}
