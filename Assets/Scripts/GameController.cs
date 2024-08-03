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
    private readonly int startingRocks = 3;

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
            // Update the game state and remaining rocks
            CurrentGameState = GameState.Aiming;
            RemainingRocks = remainingRocks - 1;

            // Destroy the rock instance and create a new one
            Destroy(rockInstance);
            rockInstance = Instantiate(rockPrefab, rockSpawnPoint.position, Quaternion.identity);
            forceController.rockMovementController = rockInstance.GetComponent<RockMovementController>();

            // Reset the force multiplier
            forceController.ResetForceMultiplier();
        }
    }

    void ReloadScene()
    {
        OnDestroy();
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddPoints(int points)
    {
        this.points += points;
        scoreController.UpdateScore(this.points);
        remainingBallons--;
        if (remainingBallons == 0)
        {
            ReloadScene();
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
