using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMovement : MonoBehaviour
{
    private CameraController cameraController;

    public float Speed = 1.0f;
    public float Offset = 2.0f;

    void Awake()
    {
        cameraController = FindObjectOfType<CameraController>();
        if (Speed > 0)
        {
            cameraController.PositionObjectOutsideLeft(transform, Offset);
        }
        else
        {
            cameraController.PositionObjectOutsideRight(transform, Offset);
        }
    }

    void Update()
    {
        transform.Translate(Speed * Time.deltaTime * Vector3.right);
    }

}
