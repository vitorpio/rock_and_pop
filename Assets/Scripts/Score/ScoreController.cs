using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private readonly string prefix = "Pontuação: ";

    private Text scoreText;

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
