using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    
    void Awake()
    {
        SetupSingleton();
    }

    void SetupSingleton()
    {
        int musicPlayerCount = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;
        if (musicPlayerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
