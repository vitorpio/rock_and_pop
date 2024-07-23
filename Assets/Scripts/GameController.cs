using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private GameObject remainingRocksNumber;
    private int _startingRocks = 3;
    private int _remainingRocks;
    private ForceController forceController;
    private GameObject rockInstance;

    public int RemainingRocks
    {
        get { return RemainingRocks; }
        set
        {
            _remainingRocks = value;
            remainingRocksNumber.GetComponent<UnityEngine.UI.Text>().text = _remainingRocks.ToString();
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
    }

    public void ResetRock()
    {
        Destroy(rockInstance);
        rockInstance = Instantiate(rockPrefab, rockSpawnPoint.position, Quaternion.identity);
        forceController.rockMovementController = rockInstance.GetComponent<RockMovementController>();
        CurrentGameState = GameState.Aiming;
        RemainingRocks = _remainingRocks - 1;
    }

}
