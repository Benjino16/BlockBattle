using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [Header("Lasergun Settings;")]
    [SerializeField] float damage = 1f;
    [SerializeField] float range = 100f;
    [SerializeField] float cooldownTime = 10f;
    [SerializeField] float duration = 4f;
    [SerializeField] float damageDelay = 0.1f;

    float timer;
    bool shooting = false;
    bool cooldown = false;

    private void Awake()
    {
        timer = damageDelay;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f && shooting)
        {
            FrameShoot();
            timer = damageDelay;
        }
    }

    public void Shoot()
    {
        if(!cooldown)
        {
            StartCoroutine(ShootDurationTimer());
        }
    }

    private void FrameShoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, range);
        if(hit)
        {
            if(hit.collider.GetComponent<Health>() != null)
            {
                hit.collider.GetComponent<Health>().Damage(damage, gameObject);
            }
            
        }
    }

    IEnumerator ShootDurationTimer()
    {
        shooting = true;
        yield return new WaitForSeconds(duration);
        shooting = false;
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        cooldown = false;
    }
}
