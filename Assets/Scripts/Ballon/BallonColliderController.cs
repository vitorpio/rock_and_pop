using UnityEngine;

public class BallonColliderController : MonoBehaviour
{
    private GameController gameController;

    public int Points;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameController.AddPoints(Points);
        }
    }

}
