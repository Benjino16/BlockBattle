using System.Collections;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    [Header("Lasergun Settings;")]
    [SerializeField] float damage = 1f;
    [SerializeField] float range = 100f;
    [SerializeField] public float cooldownTime = 10f;
    [SerializeField] float duration = 4f;
    [SerializeField] float damageDelay = 0.1f;
    [Tooltip("When on the laser hits all objects in a certain range. Otherwise it will just hit the first one.")]
    [SerializeField] bool throughObjects = true;

    [Space]
    [Header("Additional Settings:")]
    [Tooltip("Useful vor bosses. You just have to activate the object.")]
    [SerializeField] public bool instantOn;

    [Space]
    [Header("Graphic Settings:")]
    [SerializeField] GameObject laser;


    float timer;
    bool shooting = false;
    bool cooldown = false;

    private void Awake()
    {
        timer = damageDelay;
        if (instantOn)
        {
            shooting = true;
            laser.SetActive(true);
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (instantOn)
        {
            if (timer <= 0f)
            {
                FrameShoot();
                timer = damageDelay;
            }
        }
        else
        {

            if (timer <= 0f && shooting)
            {
                FrameShoot();
                timer = damageDelay;
            }
        }
    }

    public void Shoot()
    {
        if (!cooldown)
        {
            StartCoroutine(ShootDurationTimer());
        }
    }

    private void FrameShoot()
    {
        if (throughObjects)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.up, range);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.GetComponent<Health>() != null)
                {
                    hit.collider.GetComponent<Health>().Damage(damage, gameObject);
                }
            }
            laser.transform.localPosition = new Vector2(0, range);
            laser.transform.localScale = new Vector3(1, range, 1);
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, range);
            if (hit)
            {
                if (hit.collider.GetComponent<Health>() != null)
                {
                    hit.collider.GetComponent<Health>().Damage(damage, gameObject);
                }

            }
            float distance = Vector2.Distance(transform.position, hit.point);
            laser.transform.localPosition = new Vector2(0, distance);
            laser.transform.localScale = new Vector3(1, distance, 1);
        }
    }

    IEnumerator ShootDurationTimer()
    {
        shooting = true;
        laser.SetActive(true);
        yield return new WaitForSeconds(duration);
        shooting = false;
        laser.SetActive(false);
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        cooldown = false;
    }
}
