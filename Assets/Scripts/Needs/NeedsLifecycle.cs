using System.Collections.Generic;
using UnityEngine;

public class NeedsLifecycle : MonoBehaviour
{

    public HealthController healthController;
    public ScoreController scoreController;

    private List<Need> instantiatedNeeds;

    void Start()
    {
        instantiatedNeeds = new List<Need>();
    }

    public void AddNeed(Need need)
    {
        instantiatedNeeds.Add(need);
    }

    public void RemoveNeed(string tag, bool withDamage = false)
    {
        Need need = instantiatedNeeds.Find(it => it.tag.Equals(tag));
        if (need != null)
        {
            if (withDamage)
            {
                AudioSource soundEffect = gameObject.GetComponent<AudioSource>();
                soundEffect.Play();
                scoreController.UpdateScore(-need.healthDamage);
                healthController.RemoveHealth(need.healthDamage);
            }
            else
            {
                scoreController.UpdateScore(need.healthDamage);
            }
            instantiatedNeeds.Remove(need);
            need.DestroySelf();
        }

    }

    public bool NeedAlreadySpawned(string tag)
    {
        int index = instantiatedNeeds.FindIndex(it => it.tag.Equals(tag));

        return index == -1 ? false : true;
    }

    public void DestroyAllNeeds()
    {
        instantiatedNeeds.ForEach(need =>
        {
            if (need != null)
            {
                need.DestroySelf();
            }
        });
    }

}
