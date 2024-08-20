using UnityEngine;
using GameConfig;
using FMODUnity;
using UnityEngine.SceneManagement;

public class LeftRightController : MonoBehaviour
{
    private readonly string NextSceneName = "Level1";

    public EventReference ClickSound;

    public void ChooseLeft()
    {
        RuntimeManager.PlayOneShot(ClickSound, transform.position);

        GameParameters.LeftOrRight = -1;
        SceneManager.LoadScene(NextSceneName);
    }

    public void ChooseRight()
    {
        RuntimeManager.PlayOneShot(ClickSound, transform.position);

        GameParameters.LeftOrRight = 1;
        SceneManager.LoadScene(NextSceneName);
    }
}
