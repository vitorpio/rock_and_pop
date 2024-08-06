using System.Collections.Generic;
using UnityEngine;

public class BallonMovementController : MonoBehaviour
{
    private readonly float distanceThreshold = 0.1f;
    private int currentWaypoint = 0;

    public float Speed = 1.0f;
    public List<Transform> waypoints;

    void FixedUpdate()
    {
        Vector3 target = waypoints[currentWaypoint].position;

        if (Vector3.Distance(transform.position, target) < distanceThreshold)
        {
            if (currentWaypoint == waypoints.Count - 1)
            {
                currentWaypoint = 0;
            }
            else
            {
                currentWaypoint++;
            }
        }
        else
        {
            Vector3 moveDirection = target - transform.position;
            float distance = Speed * Time.deltaTime;
            transform.position += moveDirection.normalized * distance;
        }
    }
}
