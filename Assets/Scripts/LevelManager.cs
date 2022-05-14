using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public OnLevelText onLevelText;

    public int enemiesKilled = 0;
    public int lightKilled = 0;
    public int mediumKilled = 0;
    public int heavyKilled = 0;
    public int score = 0;

    string levelName;

    void Awake()
    {
        EventManager.OnEnemyKilled += UpdateStats;
    }

    void OnDestroy()
    {
        EventManager.OnEnemyKilled -= UpdateStats;
    }

    void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
    }

    void UpdateStats(string enemyType)
    {
        enemiesKilled++ ;

        switch (enemyType)
        {
            case "light":
                lightKilled++ ;
                break;

            case "medium":
                mediumKilled++ ;
                break;

            case "heavy":
                heavyKilled++ ;
                break;
        }

        score = lightKilled * 10 + mediumKilled * 20 + heavyKilled * 30;

        onLevelText.UpdateKilledEnemiesText(enemiesKilled, lightKilled, mediumKilled, heavyKilled, score);

        if (enemiesKilled >= 10)
        {
            if (CheckScore())
            {
                SaveScore();
            }

            EventManager.LevelPassed(score);
            Time.timeScale = 0f;
        }
    }

    void SaveScore()
    {
        SaveData data = new SaveData();

        data.heavyKilled = this.heavyKilled;
        data.mediumKilled = this.mediumKilled;
        data.lightKilled = this.lightKilled;
        data.score = this.score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/" + levelName +"_save.json", json);
    }

    bool CheckScore()
    {
        string path = Application.persistentDataPath + "/" + levelName + "_save.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            if (this.score >= data.score)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }
}

[System.Serializable]
class SaveData
{
    public int lightKilled = 0;
    public int mediumKilled = 0;
    public int heavyKilled = 0;
    public int score = 0;
}