using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float delay;
    [SerializeField] float radius;
    [SerializeField] float destroyTime;
    [SerializeField] Animator animator;

    [HideInInspector] public GameObject sender;

    float timer;
    bool strike = false;


    private void Awake()
    {
        timer = delay;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f && !strike)
        {
            Strike();
        }
        if (timer <= -destroyTime)
        {
            Debug.Log("Destroy lightning...");
            Destroy(gameObject);
        }
    }


    void Strike()
    {
        Debug.Log("Stiked at " + transform.position);
        strike = true;

        animator.Play("Lightning_Animation");

        foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, radius))
        {
            if (collider.GetComponent<Health>() != null)
            {
                collider.GetComponent<Health>().Damage(damage, sender);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
