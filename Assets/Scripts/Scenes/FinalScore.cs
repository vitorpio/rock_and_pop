using UnityEngine;
using UnityEngine.SceneManagement;
using GameConfig;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    private readonly string NextSceneName = "Level1";

    public Text ScoreText;

    void Awake()
    {
        ScoreText.text = GameParameters.TotalPoints.ToString();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(NextSceneName);
        GameParameters.TotalPoints = 0;
    }
}
