using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multText;
    public TextMeshProUGUI DeathScore;
    public HighScoreManager manager;
    private int score = 0;
    private int scoreAdd = 10;
    private int nextTrigger = 50;
    private int upgradeCount = 0;

    public int baseScoreMultiplier = 1;
    public int activeMultipliers = 0;
    public int scoreMultiplier = 1;


    void Start()
    {
        RecalculateMultiplier();
        UpdateScoreUI();
    }

    public void AddScore()
    {
        score += scoreAdd * scoreMultiplier;
        UpdateScoreUI();
        CheckProgression();
        manager.HighScoreUpdater(score);
    }

    public void RecalculateMultiplier()
    {
        scoreMultiplier = baseScoreMultiplier * (int)Mathf.Pow(2, activeMultipliers);
        multText.text = scoreMultiplier + "x";
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
        DeathScore.text = "Your Score:\n" + score;
    }

    private void CheckProgression()
    {
        if (score >= nextTrigger)
        {
            upgradeCount++;

            scoreAdd *= 2; // Only scale by 2, don't multiply with multiplier
            nextTrigger *= 3;

            Debug.Log($"Upgrade #{upgradeCount}: ScoreAdd is now {scoreAdd}");
            Debug.Log($"Next trigger at {nextTrigger}");

            FindObjectOfType<spawnmanager>().IncreaseEnemySpeed();

            if (upgradeCount % 2 == 0)
            {
                FindObjectOfType<spawnmanager>().IncreaseSpawnrate();
            }
        }
    }

    public int GetScore()
    {
        return score;
    }
}
