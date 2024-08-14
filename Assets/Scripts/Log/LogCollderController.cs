using UnityEngine;

public class LogCollderControoler : MonoBehaviour
{

    public GameObject PowEffectPrefab;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(PowEffectPrefab, other.transform.position, Quaternion.identity);
            Destroy(other);
        }
    }


}
