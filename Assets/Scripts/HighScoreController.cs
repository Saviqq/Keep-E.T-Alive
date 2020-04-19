using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HighScoreController : MonoBehaviour
{
    public Button newGameButton;
    public Button exitGameButton;

    private void Awake()
    {
        Button newGame = newGameButton.GetComponent<Button>();
        newGame.onClick.AddListener(StartGame);

        Button exit = exitGameButton.GetComponent<Button>();
        exit.onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
