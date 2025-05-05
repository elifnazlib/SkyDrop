using UnityEngine;

// This script manages high score and background music.
// It uses the Singleton pattern to ensure only one instance exists throughout the game.
public class Singleton : MonoBehaviour
{
    private static Singleton instance = null;
    private AudioSource audioSource;

    public int highScore = 0;

    public static Singleton Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
    
}