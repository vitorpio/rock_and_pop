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

    public GameState CurrentGameState { get; set; }
    private int _startingRocks = 3;
    private int _remainingRocks;
    private GameObject remainingRocksNumber;
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
        remainingRocksNumber = GameObject.Find("RemainingRocksNumber");
        CurrentGameState = GameState.Aiming;
        RemainingRocks = _startingRocks;
    }

}
