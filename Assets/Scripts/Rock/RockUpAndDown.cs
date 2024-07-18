using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockUpAndDown : MonoBehaviour
{
    private GameController gameController;
    private ForceController forceController;
    private AimController aimController;
    private RockMovementController rockMovementController;
    private Rigidbody2D rigidbody;

    private float rockScale = 0.5f;
    private float maxRockScale = 0.5f;
    private float minRockScale = 0.3f;
    private float rockResizeScale = 0.02f;
    private float rockDelayScale = 0.02f;
    private float dragForceHitWater = 0.25f;
    private bool isIncreasing = false;

    private Coroutine updateRockScaleCoroutine;

    public GameObject WavePrefab;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        forceController = FindObjectOfType<ForceController>();
        aimController = FindObjectOfType<AimController>();
        rockMovementController = GetComponent<RockMovementController>();
        rigidbody = GetComponent<Rigidbody2D>();
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
                    Instantiate(WavePrefab, transform.position, Quaternion.identity);
                    rockMovementController.ApplyForce(aimController.Angle, forceController.forceMultiplier * dragForceHitWater * -1);
                }
                transform.localScale = new Vector3(rockScale, rockScale, rockScale);
                yield return new WaitForSeconds(rockDelayScale * (forceController.maxForceMultiplier / rigidbody.velocity.magnitude));
            }
        }
    }
}
