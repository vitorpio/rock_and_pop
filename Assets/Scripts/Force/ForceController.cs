using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceController : MonoBehaviour
{
    private GameController gameController;


    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }


    void Update()
    {
        if (gameController.CurrentGameState == GameState.Aiming)
        {
            CheckShoot();
        }
        else if (gameController.CurrentGameState == GameState.Shooting)
        {
            CheckReleaseShot();
        }
    }

    void CheckShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameController.CurrentGameState = GameState.Shooting;
        }
    }

    void CheckReleaseShot()
    {
        if (Input.GetMouseButtonUp(0))
        {
            gameController.CurrentGameState = GameState.WaitingForNextTurn;
        }
    }
}
