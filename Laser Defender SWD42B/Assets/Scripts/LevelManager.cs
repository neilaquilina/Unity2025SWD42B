using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   
    public void LoadStartMenu()
    {
        // Load the scene with index 0
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        // Load the scene named "LaserDefender"
        SceneManager.LoadScene("LaserDefender");
    }

    public void LoadGameOver()
    {
        // Load the scene named "GameOver"
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }

}
