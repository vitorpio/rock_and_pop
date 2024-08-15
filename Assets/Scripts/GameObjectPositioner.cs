using UnityEngine;

public class GameObjectPositioner : MonoBehaviour
{
    private Camera mainCamera; // Assign the main camera in the Inspector
    public Vector2 viewportPosition; // Set the viewport position (0 to 1)

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Start()
    {
        PositionGameObject();
    }

    void PositionGameObject()
    {
        if (mainCamera != null)
        {
            // Convert viewport position to world position
            Vector3 worldPosition = mainCamera.ViewportToWorldPoint(new Vector3(viewportPosition.x, viewportPosition.y, mainCamera.nearClipPlane));

            // Set the object's position
            transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
        }
        else
        {
            Debug.LogError("Main camera is not assigned.");
        }
    }
}