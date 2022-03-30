using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] Bullet bullet;
    [SerializeField] float shootingSpeed;

    [SerializeField] GameObject gunOwner;

    float waitingTime = 0f;

    private void Update()
    {
        waitingTime += Time.deltaTime;
    }

    public void Shoot()
    {
        if(waitingTime > shootingSpeed)
        {
            Bullet newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.sender = gunOwner;

            waitingTime = 0f;
        }
    }
}
