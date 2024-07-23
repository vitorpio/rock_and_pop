using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovementController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private GameController gameController;

    private float minVelocityNotToSink = 2.0f;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ApplyForce(float angle, float forceMultipliyer)
    {
        // Change angle signal unity to math
        angle = -angle;

        // Ensure the angle is between -90 and 90 degrees
        angle = Mathf.Clamp(angle, -90, 90);
        // Convert angle to radians for Mathf.Sin and Mathf.Cos
        float angleInRadians = angle * Mathf.Deg2Rad;

        // Calculate direction vector based on the angle
        Vector2 forceVector = new Vector2(Mathf.Sin(angleInRadians), Mathf.Cos(angleInRadians)) * forceMultipliyer;

        // Apply the force in the calculated direction
        rigidbody.AddForce(forceVector, ForceMode2D.Impulse);

        // If the force is negative, the rock will sink if the velocity is less than minVelocityNotToSink
        if (rigidbody.velocity.magnitude < minVelocityNotToSink && forceMultipliyer < 0)
        {
            gameController.ResetRock();
        }
    }

}
