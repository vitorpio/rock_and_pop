using UnityEngine;

public class RockSpin : MonoBehaviour
{
    private readonly float spinSpeed = 1;

    private GameController gameController;
    private AimController aimController;
    private new Rigidbody2D rigidbody;

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
