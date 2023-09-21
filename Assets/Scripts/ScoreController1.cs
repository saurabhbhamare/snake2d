using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController1 : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public int score1 = 0;
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        RefreshUIScore();
    }
    public void IncreaseScore(int incscore)
    {
        score1 += incscore;
        RefreshUIScore();
    }
    private void RefreshUIScore()
    {
        scoreText.text = "Player 1 Score : " + score1;
    }
    public int  ReturnScore()
    {
        return score1;
    }
}
