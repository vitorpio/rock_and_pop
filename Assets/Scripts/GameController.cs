using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Aiming,
    Shooting,
    WaitingForNextTurn,
    GameOver
}

public class GameController : MonoBehaviour
{
    private readonly int startingRocks = 5;

    private GameObject remainingRocksNumber;
    private Transform rockSpawnPoint;
    private ForceController forceController;
    private GameObject rockInstance;
    private ScoreController scoreController;
    private int remainingRocks;

    public GameState CurrentGameState = GameState.Aiming;
    public GameObject rockPrefab;
    public int points = 0;
    public int remainingBallons;
    public string nextSceneName;

    public int RemainingRocks
    {
        get { return RemainingRocks; }
        set
        {
            // If the remaining rocks is 0, reload the scene GAME-OVER
            if (value == 0)
            {
                ReloadScene();
            }
            else
            {
                remainingRocks = value;
                remainingRocksNumber.GetComponent<UnityEngine.UI.Text>().text = remainingRocks.ToString();
            }
        }
    }

    void Awake()
    {
        remainingRocksNumber = GameObject.Find("RemainingRocksNumber");
        rockSpawnPoint = GameObject.Find("Pivot").transform;
        forceController = FindObjectOfType<ForceController>();
        remainingBallons = GameObject.FindGameObjectsWithTag("Ballon").Length;
        scoreController = FindObjectOfType<ScoreController>();
    }

    void Start()
    {
        rockInstance = Instantiate(rockPrefab, rockSpawnPoint.position, Quaternion.identity);
        forceController.rockMovementController = rockInstance.GetComponent<RockMovementController>();
        RemainingRocks = startingRocks;
    }

    public void ResetRock()
    {
        if (rockInstance != null && rockSpawnPoint != null)
        {
            Destroy(rockInstance);

            // Update the remaining rocks
            RemainingRocks = remainingRocks - 1;

            // If there are no more rocks, reload the scene
            if (CurrentGameState == GameState.GameOver)
            {
                return;
            }

            // Set the game state to aiming if there are remaining rocks
            CurrentGameState = GameState.Aiming;

            // Create a new rock instance
            rockInstance = Instantiate(rockPrefab, rockSpawnPoint.position, Quaternion.identity);
            forceController.rockMovementController = rockInstance.GetComponent<RockMovementController>();

            // Reset the force multiplier
            forceController.ResetForceMultiplier();
        }
    }

    void ReloadScene()
    {
        // Check if level is completed before reloading the scene
        if (remainingBallons == 0)
        {
            return;
        }

        CurrentGameState = GameState.GameOver;
        if (GameObject.FindGameObjectsWithTag("Effect").Count() > 0)
        {
            Invoke(nameof(ReloadScene), 0.5f);
            return;
        }
        OnDestroy();
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void LoadNextScene()
    {
        if (GameObject.FindGameObjectsWithTag("Effect").Count() > 0)
        {
            Invoke(nameof(LoadNextScene), 0.5f);
            return;
        }
        SceneManager.LoadScene(nextSceneName);
    }

    public void AddPoints(int points)
    {
        this.points += points;
        scoreController.UpdateScore(this.points);
        remainingBallons--;
        if (remainingBallons == 0)
        {
            if (nextSceneName != null)
            {
                LoadNextScene();
            }
            else
            {
                ReloadScene();
            }
        }
    }

    void OnDestroy()
    {
        // Ensure that the rock instance is destroyed when the scene is unloaded
        if (rockInstance != null)
        {
            Destroy(rockInstance);
            rockInstance = null;
        }
    }


}
