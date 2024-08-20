using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackBlossom : MonoBehaviour
{
    private readonly string NextSceneName = "Title";
    private readonly float Delay = 3;

    void Awake()
    {
        Invoke(nameof(LoadNextScene), Delay);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(NextSceneName);
    }

}
