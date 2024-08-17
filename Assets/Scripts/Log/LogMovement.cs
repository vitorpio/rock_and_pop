using UnityEngine;

public class LogMovement : MonoBehaviour
{
    private GameObjectPositioner gameObjectPositioner;

    public float Speed = 1.0f;

    void Awake()
    {
        gameObjectPositioner = GetComponent<GameObjectPositioner>();
    }

    void Update()
    {
        transform.Translate(Speed * Time.deltaTime * Vector3.right);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCamera"))
        {
            gameObjectPositioner.PositionGameObject();
        }
    }

}
