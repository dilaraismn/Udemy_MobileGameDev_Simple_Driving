using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private int maxEnergy;
    [SerializeField] private int energyRechargeDuration;

    private int energy;

    private const string EnergyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";


    private void Start()
    {
        int highScore = PlayerPrefs.GetInt(ScoreHandler.HighScoreKey, 0);

        highScoreText.text = $"High Score: {highScore}";
        //highScoreText.text = "High Score :" + highScore.ToString();
        // highScoreText.text = highScore.ToString();

        energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy);
        //check how much energy we've got

        if (energy == 0) //if we're out of energy
        {
            string energyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);
            //check when energy should be regenerated

            if (energyReadyString == string.Empty) return;

            DateTime energyReady = DateTime.Parse(energyReadyString);
            //find out when our energy will be regenerated and convert it 

            if (DateTime.Now > energyReady) // compare two different date types - current and when it will be ready
            {
                //if its bigger we've already passed that time and our energy is ready so we set it to max
                energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);
            }
        }


        energyText.text = $"Play ({energy})";
    }

    public void Play()
    {
        if(energy < 1) return;

        energy--;
        
        PlayerPrefs.SetInt(EnergyKey, energy);

        if (energy == 0)
        {
            DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDuration);
            PlayerPrefs.SetString(EnergyReadyKey, energyReady.ToString());
        }
        
        

        
        SceneManager.LoadScene(1);
    }
}
