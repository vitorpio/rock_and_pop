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

    void Start()
    {
        CurrentGameState = GameState.Aiming;
    }


    void Update()
    {

    }
}
