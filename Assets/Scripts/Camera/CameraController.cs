using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameController gameController;
    private BoxCollider2D boxCollider;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        boxCollider = GetComponent<BoxCollider2D>();
        UpdateColliderSize();
    }

    void UpdateColliderSize()
    {
        Camera camera = Camera.main;
        if (camera != null)
        {
            float height = 2f * camera.orthographicSize;
            float width = height * camera.aspect;

            // Create a box collider with the size of the camera
            boxCollider.size = new Vector2(width, height);
            boxCollider.isTrigger = true; // Set the collider as a trigger
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameController.ResetRock();
        }
        else if (other.CompareTag("Log"))
        {
            LogMovement logMovement = other.GetComponent<LogMovement>();
            if (logMovement.Speed > 0)
            {
                PositionObjectOutsideLeft(logMovement.transform, logMovement.Offset);
            }
            else
            {
                PositionObjectOutsideRight(logMovement.transform, logMovement.Offset);
            }
        }
    }

    public void PositionObjectOutsideLeft(Transform objectTransform, float offset)
    {
        Camera camera = Camera.main;
        if (camera != null)
        {
            float height = 2f * camera.orthographicSize;
            float width = height * camera.aspect;

            // Calculate the left boundary of the camera
            float leftBoundary = camera.transform.position.x - width / 2;

            // Position the object just outside the left boundary
            objectTransform.position = new Vector3(leftBoundary - offset, objectTransform.position.y, objectTransform.position.z);
        }
    }

    public void PositionObjectOutsideRight(Transform objectTransform, float offset)
    {
        Camera camera = Camera.main;
        if (camera != null)
        {
            float height = 2f * camera.orthographicSize;
            float width = height * camera.aspect;

            // Calculate the right boundary of the camera
            float rightBoundary = camera.transform.position.x + width / 2;

            // Position the object just outside the right boundary
            objectTransform.position = new Vector3(rightBoundary + offset, objectTransform.position.y, objectTransform.position.z);
        }
    }

}
