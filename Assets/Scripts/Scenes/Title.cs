using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class Title : MonoBehaviour
{
    private readonly string NextSceneName = "LeftOrRight";

    public EventReference ClickSound;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RuntimeManager.PlayOneShot(ClickSound, transform.position);
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(NextSceneName);
    }
}
