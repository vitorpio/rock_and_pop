using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConfig;
using UnityEngine.SceneManagement;

public class LeftRightController : MonoBehaviour
{
    private string FIRST_LEVEL_NAME = "Level1";

    public void ChooseLeft()
    {
        GameParameters.LeftOrRight = -1;
        SceneManager.LoadScene(FIRST_LEVEL_NAME);
    }

    public void ChooseRight()
    {
        GameParameters.LeftOrRight = 1;
        SceneManager.LoadScene(FIRST_LEVEL_NAME);
    }
}
