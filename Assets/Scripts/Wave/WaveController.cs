using UnityEngine;

public class WaveController : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("WaveStoped"))
        {
            Destroy(gameObject);
        }
    }
}
