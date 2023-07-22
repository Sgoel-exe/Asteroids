using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI highScore;

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
        else
        {
            highScore.text = "No Player Record";
        }
        
    }
}
