using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "NewHighscoreData", menuName = "GameData/HighscoreData")]
public class HighscoreData : ScriptableObject
{
    public int highscore;

    private static string SavePath => Path.Combine(Application.persistentDataPath, "highscore.json");

    [System.Serializable]
    private class HighscoreSave
    {
        public int highscore;
    }

    public void Save()
    {
        HighscoreSave save = new HighscoreSave { highscore = this.highscore };
        string json = JsonUtility.ToJson(save, true);
        File.WriteAllText(SavePath, json);
        Debug.Log("Highscore saved to " + SavePath);
    }

    public void Load()
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);
            HighscoreSave save = JsonUtility.FromJson<HighscoreSave>(json);
            this.highscore = save.highscore;
            Debug.Log("Highscore loaded: " + this.highscore);
        }
        else
        {
            Debug.Log("No highscore file found, using default.");
            this.highscore = 0;
        }
    }
    public void ResetHighscore()
    {
        highscore = 0;
        Save(); 
    }

    public void SetHighscore(int score)
    {
        if (score > highscore)
        {
            highscore = score;
            Save();
        }
    }
}
