using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public Transform DotsTransform;
    public Transform PivotTransform;

    public int Sensitivity = 100;

    private float lastMouseX;

    // Start is called before the first frame update
    void Start()
    {
        lastMouseX = Input.mousePosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        MoveAim();
    }

    void MoveAim()
    {
        Debug.Log(DotsTransform.localEulerAngles.z);
        // Calculate the difference in the mouse's X position from the last frame
        float mouseXDelta = Input.mousePosition.x - lastMouseX;

        // Update lastMouseX to the current mouse X position for the next frame
        lastMouseX = Input.mousePosition.x;

        // If the mouse moved left, mouseXDelta will be negative
        // Rotate Dots around Pivot in the opposite direction
        if (mouseXDelta != 0)
        {
            // Rotate Dots around Pivot. Adjust the rotation speed if necessary.
            DotsTransform.RotateAround(PivotTransform.position, Vector3.forward, -mouseXDelta * Time.deltaTime * Sensitivity); // Multiplied by 10 for sensitivity adjustment

            // Convert localEulerAngles.z to a range of -180 to 180 for easier comparison
            float zAngle = DotsTransform.localEulerAngles.z > 180 ? DotsTransform.localEulerAngles.z - 360 : DotsTransform.localEulerAngles.z;

            // Check if the rotation is outside the allowed range
            if (zAngle > 90 || zAngle < -90)
            {
                DotsTransform.RotateAround(PivotTransform.position, Vector3.forward, mouseXDelta * Time.deltaTime * Sensitivity); // Multiplied by 10 for sensitivity adjustment
            }

        }

    }
}
