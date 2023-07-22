using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Scoreing : MonoBehaviour
{
    private int score;
    // Start is called before the first frame update
    void Start()
    {

    }

    public int GetScore() { return score; }

    public void AddScore()
    {
        score++;
    }
    
    public void LoadHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if(PlayerPrefs.GetInt("HighScore") < this.score)
            {
                PlayerPrefs.SetInt("HighScore", this.score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", this.score);
        }
    }

}
