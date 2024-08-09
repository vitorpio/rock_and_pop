using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogCollderControoler : MonoBehaviour
{
    private GameController gameController;

    public GameObject PowEffectPrefab;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(PowEffectPrefab, other.transform.position, Quaternion.identity);
            Destroy(other);
        }
    }


}
