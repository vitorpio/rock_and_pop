using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonMovementController : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed = 1.0f;
    public int currentWaypoint = 0;

    private float distanceThreshold = 0.1f;


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
            float distance = speed * Time.deltaTime;
            transform.position += moveDirection.normalized * distance;
        }
    }
}
