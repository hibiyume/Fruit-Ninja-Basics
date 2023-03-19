using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    [SerializeField] private int score;
    [SerializeField] private int highscore;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;

    [Header("Game Over Elements")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverPanelScoreText;
    [SerializeField] private float gameOverPanelScoreTextFontSize = 72f;

    private bool hadBeenHighscore = false; // Used when GameOverPanel appears
    
    private void Awake() // Game started
    {
        gameOverPanel.SetActive(false);

        scoreText.text = "0";
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Best: " + highscore;
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            highscoreText.text = "Best: " + highscore;
            hadBeenHighscore = true;
        }
    }

    public void OnBombHit() // Game ended
    {
        Time.timeScale = 0;

        if (hadBeenHighscore)
        {
            gameOverPanelScoreText.fontSize *= 0.8f;
            gameOverPanelScoreText.text = "Nice! Your score was " + score.ToString() + "\nYou have set a new high score!";
            hadBeenHighscore = false;
        }
        else
        {
            gameOverPanelScoreText.fontSize = gameOverPanelScoreTextFontSize;
            gameOverPanelScoreText.text = "Your score was " + score.ToString();
        }

        gameOverPanel.SetActive(true);
    }

    public void RestartGame() // Game restarted
    {
        score = 0;
        scoreText.text = score.ToString();
        
        gameOverPanel.SetActive(false);
        gameOverPanelScoreText.text = "Your score was N/A";

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }
        
        Time.timeScale = 1;
    }
}
