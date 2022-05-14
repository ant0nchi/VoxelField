using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPassedFade : MonoBehaviour // INHERITANCE + ABSTRACTION
{
    public Text Score;

    void Awake()
    {
        EventManager.OnLevelPassed += ActivateLevelPassedFade;
    }

    void OnDestroy()
    {
        EventManager.OnLevelPassed -= ActivateLevelPassedFade;
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    void ActivateLevelPassedFade(int score)
    {
        Score.text = "YOUR SCORE: " + score;
        gameObject.SetActive(true);
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
