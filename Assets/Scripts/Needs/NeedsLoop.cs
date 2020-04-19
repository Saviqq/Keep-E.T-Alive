using UnityEngine;

public class NeedsLoop : MonoBehaviour
{
    public GameController gameController;
    public int maxSecToNewNeed;
    public int minSecToNewNeed;
    public int secToHigherDifficulty;

    public int maxTimeUntilNeedActive;
    public int minTimeUntilNeedActive;

    private float currentLoopSec;
    private int currentSecToNewNeed;
    [HideInInspector]
    public int currentSecUntilNeedActive;

    private NeedsFactory needsFactory;

    void Start()
    {
        needsFactory = GetComponentInParent<NeedsFactory>();
        currentSecToNewNeed = maxSecToNewNeed;
        currentSecUntilNeedActive = maxTimeUntilNeedActive;
        InvokeRepeating("SpawnNeed", 3f, currentSecToNewNeed);
        currentLoopSec = -3f;
    }

    void Update()
    {
        currentLoopSec += Time.deltaTime;
        if (!gameController.IsGameOver)
        {
            if (currentLoopSec >= secToHigherDifficulty)
            {
                CancelInvoke();
                if (currentSecToNewNeed > minSecToNewNeed)
                {
                    currentSecToNewNeed--;
                    Debug.Log(currentSecToNewNeed);

                }
                if (currentSecUntilNeedActive > minTimeUntilNeedActive)
                {
                    currentSecUntilNeedActive--;
                    Debug.Log(currentSecUntilNeedActive);
                }
                InvokeRepeating("SpawnNeed", 0f, currentSecToNewNeed);
                currentLoopSec = 0f;
            }
        }
        else
        {
            CancelInvoke();
            needsFactory.DestroyAllNeeds();
        }
    }

    private void SpawnNeed()
    {
        needsFactory.CreateNeed();
    }
}
