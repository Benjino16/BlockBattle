using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float speed;
    [SerializeField] float damage;

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
