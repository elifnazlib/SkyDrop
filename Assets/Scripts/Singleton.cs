using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance = null;
    
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

        DontDestroyOnLoad(gameObject);
    }
}