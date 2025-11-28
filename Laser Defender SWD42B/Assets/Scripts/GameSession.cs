using UnityEngine;

public class GameSession : MonoBehaviour
{
   int score = 0;

    void Awake()
    {
        SetupSingleton();
    }

    void SetupSingleton()
    {
        //make sure only one game session exists
        int gameSessionCount = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;
        if (gameSessionCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetGameSession()
    {
        Destroy(gameObject);
    }
}
