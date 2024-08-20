using UnityEngine;
using GameConfig;
using UnityEngine.SceneManagement;

public class LeftRightController : MonoBehaviour
{
    private readonly string NextSceneName = "Level1";

    public void ChooseLeft()
    {
        GameParameters.LeftOrRight = -1;
        SceneManager.LoadScene(NextSceneName);
    }

    public void ChooseRight()
    {
        GameParameters.LeftOrRight = 1;
        SceneManager.LoadScene(NextSceneName);
    }
}
