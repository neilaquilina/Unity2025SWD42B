using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    TMP_Text healthText;
    Player player;
    Slider healthSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //link healthText to the TMP_Text component on the same GameObject
        healthText = GetComponent<TMP_Text>();
        player = FindFirstObjectByType<Player>();

        healthSlider = FindFirstObjectByType<Slider>();
        healthSlider.maxValue = player.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        //update the Slider to make it change colour to Yellow when health is below 50%
        //and Red when below 20%

        //update the health display with the current health from Player
        healthText.text = player.GetHealth().ToString();

        healthSlider.value = player.GetHealth();

    }
}
