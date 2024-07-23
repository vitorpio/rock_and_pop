using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RockSpin : MonoBehaviour
{
    private GameController gameController;
    private AimController aimController;
    private Rigidbody2D rigidbody;
    private float spinSpeed = 1;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        aimController = FindObjectOfType<AimController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (gameController.CurrentGameState == GameState.WaitingForNextTurn)
        {
            transform.Rotate(0, 0, (aimController.Angle >= 0 ? spinSpeed : (spinSpeed * -1)) * rigidbody.velocity.magnitude);
        }
    }
}
