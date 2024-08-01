using System;
using System.Collections;
using System.Collections.Generic;
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

    public GameState CurrentGameState;
    public GameObject rockPrefab;
    public Transform rockSpawnPoint;
    public int points = 0;
    public int remainingBallons;

    private GameObject remainingRocksNumber;
    private int _startingRocks = 3;
    private int _remainingRocks;
    private ForceController forceController;
    private GameObject rockInstance;
    private ScoreController scoreController;

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
                _remainingRocks = value;
                remainingRocksNumber.GetComponent<UnityEngine.UI.Text>().text = _remainingRocks.ToString();
            }
        }
    }

    void Awake()
    {
        forceController = FindObjectOfType<ForceController>();
        remainingRocksNumber = GameObject.Find("RemainingRocksNumber");
        CurrentGameState = GameState.Aiming;
        RemainingRocks = _startingRocks;
        rockInstance = Instantiate(rockPrefab, rockSpawnPoint.position, Quaternion.identity);
        forceController.rockMovementController = rockInstance.GetComponent<RockMovementController>();
        remainingBallons = GameObject.FindGameObjectsWithTag("Ballon").Length;
        scoreController = FindObjectOfType<ScoreController>();
    }

    public void ResetRock()
    {
        if (rockInstance != null && rockSpawnPoint != null)
        {
            // Destroy the rock instance and create a new one
            Destroy(rockInstance);
            rockInstance = Instantiate(rockPrefab, rockSpawnPoint.position, Quaternion.identity);
            forceController.rockMovementController = rockInstance.GetComponent<RockMovementController>();

            // Reset the force multiplier
            forceController.ResetForceMultiplier();

            // Update the game state and remaining rocks
            CurrentGameState = GameState.Aiming;
            RemainingRocks = _remainingRocks - 1;
        }
    }

    void ReloadScene()
    {
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
