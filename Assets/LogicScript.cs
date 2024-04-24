using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public Text gameOverScoreText;
    public Text gameOverHighScoreText;
    public GameObject textElementToHide;
    private bool gameOverSoundPlayed = false;
    private AudioSource audioSource;
    public float volume = 0.5f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        if (playerScore > highScore)
        {
            highScore = playerScore;
        }
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (gameOverHighScoreText != null)
        {
            gameOverHighScoreText.text = "" + PlayerPrefs.GetInt("HighScoreTex");
        }

        highScore = playerScore;

        if (PlayerPrefs.GetInt("HighScoreTex") <= highScore)
        {
            PlayerPrefs.SetInt("HighScoreTex", highScore);
        }
    }

    public void gameOver()
    {
        gameOverScoreText.text = playerScore.ToString();
        gameOverScreen.SetActive(true);
        if (!gameOverSoundPlayed) 
        {
            audioSource.Play(); 
            gameOverSoundPlayed = true; 
        }

        if (textElementToHide != null)
        {
            textElementToHide.SetActive(false);
        }
    }
}
