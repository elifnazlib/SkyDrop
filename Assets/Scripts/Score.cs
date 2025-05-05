using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;
    public int lives = 3;
    [SerializeField] GameObject[] hearts;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameOver _gameOverScript;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (_gameOverScript.isGameOver)
            return;

        else if (collision.CompareTag("Parrot"))
        {
            Destroy(collision.gameObject);
            score += 10;
            scoreText.text = score.ToString();
            Debug.Log("Score: " + score);
        }

        else if (collision.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
            scoreText.text = score.ToString();

            if (score <= 20)
                score = 0;
            else
                score -= 20;

            scoreText.text = score.ToString();
            Debug.Log("Score: " + score);

            lives--;
            hearts[lives].SetActive(false);

            if (lives <= 0)
            {
                _gameOverScript.GameFinished();
            }
        }
    }

    public int GetScore()
    {
        return score;
    }
}
