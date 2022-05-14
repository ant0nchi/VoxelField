using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour // INHERITANCE + ABSTRACTION
{
    public Text[] buttonsText;

    private SaveData saveData;
    
    void Start()
    {
        Time.timeScale = 1f;
        for(int i = 0; i < buttonsText.Length; i++)
        {
            int levelIndex = i + 1;
            LoadScore("Level " + levelIndex);

            Text text = buttonsText[i];
            text.text = "LEVEL " + levelIndex + "\nHiScore: " + saveData.score +
                "\nL" + saveData.lightKilled + " M" + saveData.mediumKilled + " H" + saveData.heavyKilled;
        }
    }

    public void StartLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    void LoadScore(string levelName)
    {
        string path = Application.persistentDataPath + "/" + levelName + "_save.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            saveData = new SaveData();
        }
    }
}
