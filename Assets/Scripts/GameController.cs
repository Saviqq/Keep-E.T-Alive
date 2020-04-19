using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public bool IsGameOver { get; set; }

    public ScoreController scoreController;

    private void Awake()
    {
        IsGameOver = false;
    }

    public void GameOver()
    {
        IsGameOver = true;
        AddHighScoreEntry(scoreController.GetScore());
        scoreController.ShowGameOver();

        StartCoroutine(LoadHighScorePageAfterWhile());
    }

    private void AddHighScoreEntry(int score)
    {
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score };

        string stringHighScore = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(stringHighScore);
        if (highScores != null)
        {
            highScores.highScoreEntryList.Add(highScoreEntry);
        }
        else
        {
            highScores = new HighScores { highScoreEntryList = new List<HighScoreEntry>() };
            highScores.highScoreEntryList.Add(highScoreEntry);
        }
        string jsonHighScore = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreTable", jsonHighScore);
        PlayerPrefs.Save();
    }

    private IEnumerator LoadHighScorePageAfterWhile()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("HighScore");
    }
}
