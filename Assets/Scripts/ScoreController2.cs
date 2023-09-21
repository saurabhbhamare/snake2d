using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController2: MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public int score2 = 0;
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
        score2 += incscore;
        RefreshUIScore();
    }
    private void RefreshUIScore()
    {
        scoreText.text = "Player 2 Score : " + score2;
    }
    public int ReturnScore()
    {
        return score2;
    }
}
