using System.Collections;
using System.Collections.Generic;
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

}
