using UnityEngine;

public class GameObjectScaler : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector2 referenceResolution = new Vector2(1080, 1920);
    private Camera Camera;

    void Awake()
    {
        Camera = FindAnyObjectByType<Camera>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        AdjustScale();
    }

    void AdjustScale()
    {
        // Get the current screen resolution
        Vector2 screenResolution = new Vector2(Screen.width, Screen.height);

        // Calculate the scale factor based on the reference resolution
        float scaleFactorX = screenResolution.x / referenceResolution.x;
        float scaleFactorY = screenResolution.y / referenceResolution.y;

        // Apply the scale factor to the sprite
        transform.localScale = new Vector3(scaleFactorX, scaleFactorY, 1);
    }

    void Update()
    {
        // Optionally, adjust the scale dynamically if the screen size changes
        AdjustScale();
    }
}