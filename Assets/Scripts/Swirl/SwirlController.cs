using UnityEngine;

public class SwirlController : MonoBehaviour
{
    public float swirlForce;
    public Vector2 Direction;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rockRigidbody = other.GetComponent<Rigidbody2D>();
            rockRigidbody.velocity = Vector2.zero;
            rockRigidbody.AddForce(Direction * swirlForce, ForceMode2D.Impulse);
        }
    }

}
