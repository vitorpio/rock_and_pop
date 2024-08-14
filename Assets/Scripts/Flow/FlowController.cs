using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{
    public float flowForce;
    public Vector2 Direction;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RockUpAndDown rockUpAndDown = other.GetComponent<RockUpAndDown>();

            if (rockUpAndDown.IsTouchingWater)
            {
                Rigidbody2D rockRigidbody = other.GetComponent<Rigidbody2D>();
                rockRigidbody.AddForce(Direction * flowForce, ForceMode2D.Impulse);
            }
        }
    }
}
