using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public HighscoreData highscoreData;
    public TextMeshProUGUI HighScoreTxt;

    void Start()
    {
        highscoreData.Load();
        HighScoreTxt.text = "High Score : \n" + highscoreData.highscore;
    }

    public void HighScoreUpdater(int score)
    {
        highscoreData.SetHighscore(score);
    }

    public void GetHighScore()
    {
        HighScoreTxt.text = "High Score : \n" + highscoreData.highscore;
    }

    public void ResetScore()
    {
        highscoreData.ResetHighscore();
        HighScoreTxt.text = "High Score : \n" + highscoreData.highscore;
    }

    void OnApplicationQuit()
    {
        highscoreData.Save();
    }
}
