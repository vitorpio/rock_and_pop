using System.Collections;
using UnityEngine;

public class RockUpAndDown : MonoBehaviour
{
    private readonly float minVelocityNotToSink = 2.0f;
    private readonly float maxRockScale = 0.5f;
    private readonly float minRockScale = 0.3f;
    private readonly float rockResizeScale = 0.02f;
    private readonly float rockDelayScale = 0.01f;
    private readonly float dragForceHitWater = 0.25f;
    private float rockScale = 0.5f;

    private GameController gameController;
    private ForceController forceController;
    private AimController aimController;
    private RockMovementController rockMovementController;
    private new Rigidbody2D rigidbody;
    private bool isIncreasing = false;
    private Coroutine updateRockScaleCoroutine;

    public GameObject WavePrefab;
    public GameObject SplagPrefab;

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
                    // When the rock touches the water, it will create a wave and apply a force to the rock in the opposite direction.
                    isIncreasing = !isIncreasing;
                    // If the force is negative, the rock will sink if the velocity is less than minVelocityNotToSink
                    float forceMultipliyer = rigidbody.velocity.magnitude * dragForceHitWater * -1;
                    if (rigidbody.velocity.magnitude < minVelocityNotToSink && forceMultipliyer < 0)
                    {
                        Instantiate(SplagPrefab, transform.position, Quaternion.identity);
                        Destroy(gameObject);
                    }
                    else
                    {
                        Instantiate(WavePrefab, transform.position, Quaternion.identity);
                        rockMovementController.ApplyForce(aimController.Angle, forceMultipliyer);
                    }
                }
                transform.localScale = new Vector3(rockScale, rockScale, rockScale);
                yield return new WaitForSeconds(rockDelayScale * (forceController.maxForceMultiplier / rigidbody.velocity.magnitude));
            }
        }
    }
}
