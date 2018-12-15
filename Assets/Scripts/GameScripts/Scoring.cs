using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    [Header("UI")]
    public Text scoreText;
    public Text timeText;

    public GameObject gameOverPanel;

    public Text gameOverPanelHeadline;
    public Text gameOverPanelScore;
    public Text gameOverPanelHighScore;

    public Color winColor;
    public Color loseColor;

    [Header("Functionality")]
    [SerializeField]
    int score;

    public bool gameComplete;

    public CubeGenerator cubeGenerator;

    public float timer;

    public void UpdateScore(int value) {
        score += value;
    }

    private void LateUpdate() {
        scoreText.text = score.ToString();
        if (!cubeGenerator.empty) {
            timer -= Time.deltaTime;
            timeText.text = timer.ToString("N0");
        }

        if (cubeGenerator.checkNow) {
            if (timer > 0 && cubeGenerator.empty)
                GameOver(true);
            else if (timer < 0 && !cubeGenerator.empty)
                GameOver(false);
        }
    }

    public void GameOver(bool win) {
        gameComplete = true;
        gameOverPanel.SetActive(true);
        gameOverPanelHighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        gameOverPanelScore.text = "Your Score: " + score;
        if (win) {
            if (score > PlayerPrefs.GetInt("HighScore"))
                PlayerPrefs.SetInt("HighScore", score);
            gameOverPanelHeadline.text = "YOU WIN!";
            gameOverPanelHeadline.color = winColor;
        }
        else {
            gameOverPanelHeadline.text = "YOU LOSE!";
            gameOverPanelHeadline.color = loseColor;
        }
        Time.timeScale = 0;
    }
}
