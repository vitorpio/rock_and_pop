using UnityEngine;

public class BallonColliderController : MonoBehaviour
{
    private GameController gameController;
    private PolygonCollider2D polygonCollider;
    private SpriteRenderer spriteRenderer;

    public int Points;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        UpdatePolygonCollider();
    }

    void UpdatePolygonCollider()
    {
        // Get the sprite's vertices and update the collider points
        Vector2[] spriteVertices = spriteRenderer.sprite.vertices;
        Vector2[] colliderPoints = new Vector2[spriteVertices.Length];

        for (int i = 0; i < spriteVertices.Length; i++)
        {
            colliderPoints[i] = spriteVertices[i];
        }

        polygonCollider.points = colliderPoints;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(transform.parent.gameObject);
            gameController.AddPoints(Points);
        }
    }

}
