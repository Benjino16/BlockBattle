using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float activateDelay;
    [SerializeField] float deactivateDelay;
    [SerializeField] float timeAfterDeactivation;
    [SerializeField] GunController gunController;
    [SerializeField] int uses = 15;
    [SerializeField] float addUsesDelay = 1f;

    float addDelay;
    float deaktivationTimer;
    bool active = false;
    bool canShoot = false;


    private void Awake()
    {
        addDelay = addUsesDelay;
        deaktivationTimer = timeAfterDeactivation;
    }

    public void Update()
    {
        addDelay -= Time.deltaTime;
        deaktivationTimer -= Time.deltaTime;

        if(!active && addDelay < 0f)
        {
            uses++;
            addDelay = addUsesDelay;
        }
        if(deaktivationTimer < 0f && active)
        {
            StartCoroutine(DeactivateGun());
        }
    }
    public void TryShoot()
    {
        deaktivationTimer = timeAfterDeactivation;
        if(canShoot && uses > 0)
        {
            Shoot();
        }
        else
        {
            if(!active)
            {
                StartCoroutine(ActivateGun());
            }
        }
    }

    private void Shoot()
    {
        if(uses > 0)
        {
            uses--;
            gunController.Shoot();
        }
    }

    IEnumerator ActivateGun()
    {
        active = true;
        animator.Play("Shooter_Start");
        yield return new WaitForSeconds(activateDelay);
        canShoot = true;
    }

    IEnumerator DeactivateGun()
    {
        canShoot = false;
        animator.Play("Shooter_Stop");
        yield return new WaitForSeconds(deactivateDelay);
        active = false;
    }
}
