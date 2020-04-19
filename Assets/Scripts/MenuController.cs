using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public Button newGameButton;
    public Button highScoreButton;
    public Button exitButton;

    private void Awake()
    {
        Button newGame = newGameButton.GetComponent<Button>();
        newGame.onClick.AddListener(StartGame);

        Button highScore = highScoreButton.GetComponent<Button>();
        highScore.onClick.AddListener(ShowHighScore);

        Button exit = exitButton.GetComponent<Button>();
        exit.onClick.AddListener(ExitGame);

    }

    private void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void ShowHighScore()
    {
        SceneManager.LoadScene("HighScore");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

}
