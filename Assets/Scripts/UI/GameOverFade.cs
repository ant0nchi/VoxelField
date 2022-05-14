using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverFade : MonoBehaviour
{
    void Awake()
    {
        EventManager.OnPlayerDestroyed += ActivateGameOverFade;
    }

    void OnDestroy()
    {
        EventManager.OnPlayerDestroyed -= ActivateGameOverFade;
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    void ActivateGameOverFade()
    {
        gameObject.SetActive(true);
    }

    public void ReplayGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
