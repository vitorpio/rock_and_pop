using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceController : MonoBehaviour
{
    public int forceMultiplier = 0;
    private float forceUpdateDelay = 0.1f;
    private float minForceMultiplier = 0;
    private float maxForceMultiplier = 10;

    private GameController gameController;
    private Coroutine updateForceMultiplierCoroutine;
    private RockMovementController rockMovementController;
    private AimController aimController;

    private bool isIncreasing = true;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        rockMovementController = FindObjectOfType<RockMovementController>();
        aimController = FindObjectOfType<AimController>();
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
            updateForceMultiplierCoroutine = StartCoroutine(UpdateForceMultiplayer());
        }
    }

    void CheckReleaseShot()
    {
        if (Input.GetMouseButtonUp(0))
        {
            gameController.CurrentGameState = GameState.WaitingForNextTurn;
            StopCoroutine(updateForceMultiplierCoroutine);
            updateForceMultiplierCoroutine = null;
            rockMovementController.ApplyForce(aimController.Angle, forceMultiplier);
        }
    }

    IEnumerator UpdateForceMultiplayer()
    {
        while (gameController.CurrentGameState == GameState.Shooting)
        {
            // Check if the force multiplier is at the minimum or maximum value
            if (forceMultiplier == minForceMultiplier && !isIncreasing)
            {
                isIncreasing = true;
            }
            else if (forceMultiplier == maxForceMultiplier && isIncreasing)
            {
                isIncreasing = false;
            }

            // Update the force multiplier
            if (isIncreasing)
            {
                forceMultiplier++;
            }
            else
            {
                forceMultiplier--;
            }
            yield return new WaitForSeconds(forceUpdateDelay);
        }
    }

}
