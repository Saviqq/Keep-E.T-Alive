
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public GameObject scoreObject;
    public GameObject gameOver;

    private int score;

    private Text scoreText;
    void Start()
    {
        scoreText = scoreObject.GetComponent<Text>();
        SetScore(0);
    }


    public int GetScore()
    {
        return score;
    }

    public void SetScore(int score)
    {
        this.score = score;
        scoreText.text = "Score: " + score;
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void ShowGameOver()
    {
        scoreObject.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
        Text scoreText = gameOver.transform.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "Your final Score is: " + score;
    }
}
