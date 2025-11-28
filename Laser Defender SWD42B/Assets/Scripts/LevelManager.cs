using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] float delayInSeconds = 2f;

    IEnumerator WaitAndLoad()
    {   
        // Wait for the specified delay
        yield return new WaitForSeconds(delayInSeconds);
        // Load the Game Over scene
        SceneManager.LoadScene("GameOver");
    }

    public void LoadStartMenu()
    {
        // Load the scene with index 0
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        // Load the scene named "LaserDefender"
        SceneManager.LoadScene("LaserDefender");
        //reset GameSession
        FindFirstObjectByType<GameSession>().ResetGameSession();
    }

    public void LoadGameOver()
    {
        // Load the scene named "GameOver"
        StartCoroutine(WaitAndLoad());
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
        print("Quit Game");
    }

}
