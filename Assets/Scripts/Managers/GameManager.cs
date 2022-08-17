using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Launch game's scene
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    
    /// <summary>
    /// Quit application
    /// </summary>
    public void QuitApplication()
    {
        Application.Quit();
    }

    /// <summary>
    /// Return to main menu
    /// </summary>
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
