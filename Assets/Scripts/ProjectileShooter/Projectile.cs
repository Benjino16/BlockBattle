using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [HideInInspector] public float speed;
    [HideInInspector] public float damage;

    public GameObject sender;

    private void Start()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().Damage(damage, sender, transform.position);
        }
        Destroy(gameObject);
    }
}
