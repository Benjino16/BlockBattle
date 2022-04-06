using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Weapon
{
    [SerializeField] Animator animator;
    [SerializeField] float cooldown = 15f;
    [SerializeField] float usetime = 5f;
    [SerializeField] float animationTime = 2f;
    [SerializeField] GameObject laser;

    bool canShoot = false;


    public void Start()
    {
        StartCoroutine(animationTimer());
    }

    public override void Use()
    {
        if(canShoot)
        {
            StartCoroutine(StartLaser());
        }
        base.Use();
    }

    IEnumerator StartLaser()
    {
        canShoot = false;
        laser.SetActive(true);
        yield return new WaitForSeconds(usetime);
        laser.SetActive(false);

        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        animator.Play("LaserGun_Stop");
        yield return new WaitForSeconds(cooldown);
        animator.Play("LaserGun_Start");
        StartCoroutine(animationTimer());
    }

    IEnumerator animationTimer()
    {
        yield return new WaitForSeconds(animationTime);
        canShoot = true;
    }
}
