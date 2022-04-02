using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] MovementController movement;
    [SerializeField] Shooter shooter;
    [SerializeField] LaserController laserController;

    void Update()
    {
        movement.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

        if (Input.GetKey(KeyCode.Space))
        {
            shooter.TryShoot();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            laserController.Shoot();
        }
    }
}
