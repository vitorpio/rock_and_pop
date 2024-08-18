using UnityEngine;

public class AimController : MonoBehaviour
{
    private readonly float maxAngleShot = 90;
    private readonly int sensitivity = 15;

    private GameController gameController;
    private float lastMouseX;

    public Transform DotsTransform;
    public Transform PivotTransform;
    public float Angle = 0;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void Start()
    {
        lastMouseX = Input.mousePosition.x;
    }

    void Update()
    {
        if (gameController.CurrentGameState == GameState.Shooting)
        {
            MoveAim();
        }
        else if (gameController.CurrentGameState == GameState.Aiming)
        {
            SetInvisible(false);
        }
        else
        {
            SetInvisible(true);
        }
    }

    void MoveAim()
    {
        // Calculate the difference in the mouse's X position from the last frame
        float mouseXDelta = Input.mousePosition.x - lastMouseX;

        // Update lastMouseX to the current mouse X position for the next frame
        lastMouseX = Input.mousePosition.x;

        // If the mouse moved left, mouseXDelta will be negative
        // Rotate Dots around Pivot in the opposite direction
        if (mouseXDelta != 0)
        {
            // Rotate Dots around Pivot. Adjust the rotation speed if necessary.
            DotsTransform.RotateAround(PivotTransform.position, Vector3.forward, -mouseXDelta * Time.deltaTime * sensitivity); // Multiplied by 10 for sensitivity adjustment

            // Convert localEulerAngles.z to a range of -180 to 180 for easier comparison
            Angle = DotsTransform.localEulerAngles.z > 180 ? DotsTransform.localEulerAngles.z - 360 : DotsTransform.localEulerAngles.z;

            // Check if the rotation is outside the allowed range
            if (Angle >= maxAngleShot || Angle <= -maxAngleShot)
            {
                DotsTransform.RotateAround(PivotTransform.position, Vector3.forward, mouseXDelta * Time.deltaTime * sensitivity); // Multiplied by 10 for sensitivity adjustment
            }

        }
    }

    void SetInvisible(bool isVisible)
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = !isVisible;
        }
    }
}