using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartGameMethod()
    {
        SceneManager.LoadScene("MainGame");
    }
}
