using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] MovementController movement;

    void Update()
    {
        movement.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

    }
}
