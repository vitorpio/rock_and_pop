using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovementController : MonoBehaviour
{
    Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ApplyForce(float angle, int forceMultipliyer)
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
    }

}
