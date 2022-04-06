using System.Collections;
using UnityEngine;

public class Shooter : Weapon
{
    [SerializeField] Animator animator;
    [SerializeField] float activateDelay;
    [SerializeField] float deactivateDelay;
    [SerializeField] float timeAfterDeactivation;
    [SerializeField] ProjectileShooter projectileShooter;
    [SerializeField] int uses = 15;
    [SerializeField] float addUsesDelay = 1f;

    [Space]

    [SerializeField] string startAnimationName;
    [SerializeField] string stopAnimationName;

    float addDelay;
    float deaktivationTimer;
    bool active = false;
    bool canShoot = false;


    public override void Awake()
    {
        addDelay = addUsesDelay;
        deaktivationTimer = timeAfterDeactivation;
        base.Awake();
    }

    public void Update()
    {
        addDelay -= Time.deltaTime;
        deaktivationTimer -= Time.deltaTime;

        if (!active && addDelay < 0f)
        {
            uses++;
            addDelay = addUsesDelay;
        }
        if (deaktivationTimer < 0f && active)
        {
            StartCoroutine(DeactivateGun());
        }
    }

    public override void Use()
    {
        deaktivationTimer = timeAfterDeactivation;
        if (canShoot && uses > 0)
        {
            Shoot();
        }
        else
        {
            if (!active)
            {
                StartCoroutine(ActivateGun());
            }
        }
        base.Use();
    }

    private void Shoot()
    {
        if (uses > 0)
        {
            if(projectileShooter.Shoot()) { uses--; }
        }
    }

    IEnumerator ActivateGun()
    {
        active = true;
        animator.Play(startAnimationName);
        yield return new WaitForSeconds(activateDelay);
        canShoot = true;
    }

    IEnumerator DeactivateGun()
    {
        canShoot = false;
        animator.Play(stopAnimationName);
        yield return new WaitForSeconds(deactivateDelay);
        active = false;
    }
}
