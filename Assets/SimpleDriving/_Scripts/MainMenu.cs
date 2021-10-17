using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;


    private void Start()
    {
        int highScore = PlayerPrefs.GetInt(ScoreHandler.HighScoreKey, 0);

        highScoreText.text = $"High Score: {highScore}";
        //highScoreText.text = "High Score :" + highScore.ToString();
        // highScoreText.text = highScore.ToString();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
