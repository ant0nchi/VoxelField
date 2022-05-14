using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnLevelText : MonoBehaviour
{
    public Text enemiesCounterText;
    public Text healthText;

    void Awake()
    {
        EventManager.OnPlayerHarmed += UpdateHealthText;
    }

    void OnDestroy()
    {
        EventManager.OnPlayerHarmed -= UpdateHealthText;
    }

    void UpdateHealthText(int health)
    {
        healthText.text = "Health: " + health;
    }

    public void UpdateKilledEnemiesText(int enemiesKilled, int lightKilled, int mediumKilled, int heavyKilled, int score)
    {
        enemiesCounterText.text = "Tanks destroyed: " + enemiesKilled + "/10"
            + "\nLight: " + lightKilled
            + "\nMedium: " + mediumKilled
            + "\nHeavy: " + heavyKilled
            + "\n\nScore: " + score;
    }
}
