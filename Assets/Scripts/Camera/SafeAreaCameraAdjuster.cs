using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SafeAreaCameraAdjuster : MonoBehaviour
{
    private Camera mainCamera;
    public GameObject UIBack;
    public GameObject UIFront;

    void Awake()
    {
        mainCamera = GetComponent<Camera>();
        AdjustCameraViewport();
    }

    void AdjustCameraViewport()
    {
        UIBack.SetActive(false);
        UIFront.SetActive(false);

        Rect safeArea = Screen.safeArea;

        // Convert safe area from screen space to viewport space
        Vector2 viewportMin = new(safeArea.xMin / Screen.width, safeArea.yMin / Screen.height);
        Vector2 viewportMax = new(safeArea.xMax / Screen.width, safeArea.yMax / Screen.height);

        // Set the camera's viewport rect
        mainCamera.rect = new Rect(viewportMin.x, viewportMin.y, viewportMax.x - viewportMin.x, viewportMax.y - viewportMin.y);

        UIBack.SetActive(true);
        UIFront.SetActive(true);
    }

    void OnRectTransformDimensionsChange()
    {
        AdjustCameraViewport();
    }
}