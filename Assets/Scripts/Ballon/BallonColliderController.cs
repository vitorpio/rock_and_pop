using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallonColliderController : MonoBehaviour
{
    public int points;

    private GameController gameController;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameController.AddPoints(points);
        }
    }

}
