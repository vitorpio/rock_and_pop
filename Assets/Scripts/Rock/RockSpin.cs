using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RockSpin : MonoBehaviour
{
    private GameController gameController;
    private ForceController forceController;
    private AimController aimController;
    private float spinSpeed = 1;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        forceController = FindObjectOfType<ForceController>();
        aimController = FindObjectOfType<AimController>();
    }

    void FixedUpdate()
    {
        if (gameController.CurrentGameState == GameState.WaitingForNextTurn)
        {
            transform.Rotate(0, 0, (aimController.Angle >= 0 ? 1 : -1) * forceController.forceMultiplier);
        }
    }
}
