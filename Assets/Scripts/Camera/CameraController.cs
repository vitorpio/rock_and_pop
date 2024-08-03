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
    }
}
