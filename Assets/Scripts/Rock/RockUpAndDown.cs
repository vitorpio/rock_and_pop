using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockUpAndDown : MonoBehaviour
{
    private GameController gameController;
    private ForceController forceController;

    private float rockScale = 0.5f;
    private float maxRockScale = 0.5f;
    private float minRockScale = 0.45f;
    private float rockResizeScale = 0.01f;
    private float rockDelayScale = 0.01f;
    private bool isIncreasing = false;

    private Coroutine updateRockScaleCoroutine;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        forceController = FindObjectOfType<ForceController>();
    }


    void Update()
    {
        if (gameController.CurrentGameState == GameState.WaitingForNextTurn && updateRockScaleCoroutine == null)
        {
            updateRockScaleCoroutine = StartCoroutine(UpdateRockScale());
        }
        else if (gameController.CurrentGameState != GameState.WaitingForNextTurn && updateRockScaleCoroutine != null)
        {
            StopCoroutine(updateRockScaleCoroutine);
            updateRockScaleCoroutine = null;
        }
    }


    IEnumerator UpdateRockScale()
    {
        {
            while (gameController.CurrentGameState == GameState.WaitingForNextTurn)
            {
                if (isIncreasing && rockScale < maxRockScale)
                {
                    rockScale += rockResizeScale;
                }
                else if (!isIncreasing && rockScale > minRockScale)
                {
                    rockScale -= rockResizeScale;
                }
                else
                {
                    isIncreasing = !isIncreasing;
                    // Hit the water
                }
                transform.localScale = new Vector3(rockScale, rockScale, rockScale);
                yield return new WaitForSeconds(rockDelayScale * (forceController.maxForceMultiplier / forceController.forceMultiplier));
            }
        }
    }
}
