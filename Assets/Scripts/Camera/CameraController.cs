using System.Collections;
using System.Collections.Generic;
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
