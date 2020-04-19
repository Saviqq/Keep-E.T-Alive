using UnityEngine;

public class HealthBar : MonoBehaviour
{

    private Transform bar;

    private void Start()
    {
        bar = transform.Find("Bar");
    }

    public void SetHealth(int healthAmount)
    {
        if (bar != null)
        {
            bar.localScale = new Vector3(1f, 0.01f * healthAmount);
        }
        else
        {
            transform.Find("Bar").localScale = new Vector3(1f, 0.01f * healthAmount);
        }
    }
}
