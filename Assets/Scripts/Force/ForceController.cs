using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceController : MonoBehaviour
{
    public int minForceMultiplier = 1;
    public int maxForceMultiplier = 10;
    public int forceMultiplier;
    public int startForceMultiplier = 0;
    private float forceUpdateDelay = 0.1f;

    public RockMovementController rockMovementController;
    public List<Sprite> ForceBarSprites;

    private GameController gameController;
    private Coroutine updateForceMultiplierCoroutine;
    private AimController aimController;
    private Image forceBar;

    private bool isIncreasing = true;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        aimController = FindObjectOfType<AimController>();
        forceBar = GetComponent<Image>();
        ResetForceMultiplier();
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
            if (updateForceMultiplierCoroutine != null)
            {
                StopCoroutine(updateForceMultiplierCoroutine);
                updateForceMultiplierCoroutine = null;
            }
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
            forceBar.sprite = ForceBarSprites[forceMultiplier];
            yield return new WaitForSeconds(forceUpdateDelay);
        }
    }

    public void ResetForceMultiplier()
    {
        forceMultiplier = startForceMultiplier;
        forceBar.sprite = ForceBarSprites[forceMultiplier];
    }

}
