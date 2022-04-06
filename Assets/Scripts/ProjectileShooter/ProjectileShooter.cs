using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [SerializeField] Projectile bullet;
    [SerializeField] float shootingSpeed;
    [SerializeField] float projectileSpeed;
    [SerializeField] float damage;

    [SerializeField] GameObject gunOwner;

    float waitingTime = 0f;

    private void Update()
    {
        waitingTime += Time.deltaTime;
    }

    public bool Shoot()
    {
        if (waitingTime > shootingSpeed)
        {
            Projectile newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.sender = gunOwner;
            newBullet.speed = projectileSpeed;
            newBullet.damage = damage;

            waitingTime = 0f;
            return true;
        }
        return false;
    }
}
