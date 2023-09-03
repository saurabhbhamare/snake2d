using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score = 0;
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
        score += incscore;
        RefreshUIScore();
    }
    private void RefreshUIScore()
    {
        scoreText.text = "Your Score : " + score;
    }    
}
