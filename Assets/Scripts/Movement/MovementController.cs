using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField] float speed = 12f;
    [SerializeField] Rigidbody2D rb;

    Vector2 movementInput;

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * speed * Time.fixedDeltaTime);
    }

    public void Move(Vector2 direction)
    {
        movementInput = direction.normalized;
    }

    public void MoveTo(Vector2 direction)
    {
        movementInput = (direction - rb.position).normalized;
    }
}
