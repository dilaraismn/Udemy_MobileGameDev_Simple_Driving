using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;

    private float score;
    
    void Update()
    {
        score += Time.deltaTime * scoreMultiplier;
        // +1 score by 1 second => score += Time.deltaTime;

        scoreText.text = Mathf.FloorToInt(score).ToString();
        // to not show the decimal numbers
    }
}
