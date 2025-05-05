using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;
    public int lives = 3;
    [SerializeField] GameObject[] hearts;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameOver _gameOverScript;
    [SerializeField] AudioClip [] audioClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (_gameOverScript.isGameOver)
            return;

        else if (collision.CompareTag("Parrot"))
        {
            audioSource.PlayOneShot(audioClip[0]);

            Destroy(collision.gameObject);
            score += 100;
            scoreText.text = score.ToString();
            Debug.Log("Score: " + score);
        }

        else if (collision.CompareTag("Bomb"))
        {
            audioSource.PlayOneShot(audioClip[1], 5f);

            Destroy(collision.gameObject);
            scoreText.text = score.ToString();

            if (score <= 50)
                score = 0;
            else
                score -= 50;

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
