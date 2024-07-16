using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpin : MonoBehaviour
{
    private GameController gameController;
    private ForceController forceController;
    private float spinSpeed = 1;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        forceController = FindObjectOfType<ForceController>();
    }

    void FixedUpdate()
    {
        if (gameController.CurrentGameState == GameState.WaitingForNextTurn)
        {
            transform.Rotate(0, 0, 1 * forceController.forceMultiplier);
        }
    }
}
