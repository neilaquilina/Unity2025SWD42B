using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    TMP_Text scoreText;
    GameSession gameSession;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //link scoreText to the TMP_Text component on the same GameObject
        scoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        gameSession = FindFirstObjectByType<GameSession>();
        //update the score display with the current score from GameSession
        scoreText.text = gameSession.GetScore().ToString();

    }
}
