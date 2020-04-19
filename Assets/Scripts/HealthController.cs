using UnityEngine;

public class HealthController : MonoBehaviour
{

    public HealthBar healthBar;
    public GameController gameController;

    private int health;

    void Start()
    {
        health = 100;
        healthBar.SetHealth(health);
    }

    public int GetHealth()
    {
        return health;
    }

    public void RemoveHealth(int amount)
    {
        health -= amount;
        healthBar.SetHealth(health);
        if (health == 0)
        {
            gameController.GameOver();
        }
    }

}
