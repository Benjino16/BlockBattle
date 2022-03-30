using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] MovementController movement;
    [SerializeField] GunController gunController;
    [SerializeField] LaserController laserController;

    void Update()
    {
        movement.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

        if(Input.GetKeyDown(KeyCode.Space))
        {
            gunController.Shoot();
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            laserController.Shoot();
        }
    }
}
