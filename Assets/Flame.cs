using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    [SerializeField] Collider2D flame_area;
    [SerializeField] List<Health> livingObjectsInFlameArea;
    [SerializeField] [Range(.05f, .5f)] float damageDelay = 0.1f;
    [SerializeField] float damage = 1f;

    float damageTimer = 0f;

    private void Update()
    {
        damageTimer += Time.deltaTime;
        if(damageTimer > damageDelay)
        {
            Damage();
            damageTimer = 0f;
        }
    }
    
    private void Damage()
    {
        foreach (Health health in livingObjectsInFlameArea)
        {
            if(health != null)
            {
                health.Damage(damage, null);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Health>() != null)
        {
            livingObjectsInFlameArea.Add(collision.GetComponent<Health>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null)
        {
            livingObjectsInFlameArea.Remove(collision.GetComponent<Health>());
        }
    }
}
