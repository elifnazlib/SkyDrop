using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI gameOverScoreText;
    [SerializeField] TextMeshProUGUI gameOverHighScoreText;
    [SerializeField] Button restartButton;
    public bool isGameOver = false;

    public void GameFinished()
    {
        isGameOver = true;
        Debug.Log("Oyun Bitti!");
        spawner.gameObject.GetComponent<Spawner>().enabled = false;

        Score score = FindObjectOfType<Score>();
        int currentScore = score.GetScore();
        int highScore = Singleton.Instance.highScore;

        if (currentScore > highScore)
        {
            Singleton.Instance.highScore = currentScore;
            Debug.Log("New Highest Score: " + currentScore);
        }
        else
        {
            Debug.Log("Highest Score: " + highScore);
        }

        gameOverPanel.SetActive(true);
        gameOverScoreText.text = currentScore.ToString();
        gameOverHighScoreText.text = Singleton.Instance.highScore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
