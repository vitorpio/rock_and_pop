using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private Text scoreText;
    private string prefix = "Pontuação: ";

    void Awake()
    {
        scoreText = GetComponent<Text>();
        UpdateScore(0);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = prefix + score.ToString();
    }

}
