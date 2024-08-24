using UnityEngine;
using GameConfig;
using FMODUnity;
using UnityEngine.SceneManagement;

public class LeftRightController : MonoBehaviour
{
    private readonly string NextSceneName = "Transition";

    public EventReference ClickSound;
    public GameObject UIBack;
    public GameObject UIFront;

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
