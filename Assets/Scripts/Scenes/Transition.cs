using UnityEngine.SceneManagement;
using UnityEngine;

public class Transition : MonoBehaviour
{
    private readonly string NextSceneName = "Level1";

    void Awake()
    {
        Invoke(nameof(LoadNextScene), 0.5f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(NextSceneName);
    }
}
