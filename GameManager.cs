using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score;
    public Text scoreText;
    public Text highScoreText;

    private void Awake()
    {
        //get highscore
        highScoreText.text = "Best: " + GetHighScore().ToString();
    }
    public void StartGame()
    {
        gameStarted = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame(); //start the game when user press the return key
        }

    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);//load scene with index 0
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        //set the high score here
        if (score > GetHighScore())
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text = "Best: " + score.ToString();

        }
    }

    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("Highscore");
        return i;

    }
}
