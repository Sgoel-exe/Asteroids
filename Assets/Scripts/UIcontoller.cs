using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIcontoller : MonoBehaviour
{
    public TextMeshProUGUI textfield;
    private Scoreing gameScore;
    // Start is called before the first frame update
    void Start()
    {
        gameScore = GameObject.FindGameObjectWithTag("GameScorel").GetComponent<Scoreing>();
    }

    public void UpdateScore()
    {
        textfield.text = gameScore.GetScore().ToString();
    }
}
