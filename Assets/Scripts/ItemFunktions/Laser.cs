using UnityEngine;

public class Laser : MonoBehaviour
{

    [Header("Lasergun Settings;")]
    [SerializeField] float damage = 1f;
    [SerializeField] float range = 100f;
    [SerializeField] [Range(.01f, 0.3f)] float damageDelay = 0.1f;
    [Space]
    [Tooltip("When on the laser hits all objects in a certain range. Otherwise it will just hit the first one.")]
    [SerializeField] bool throughObjects = true;

    [Space]
    [Header("Graphic Settings:")]
    [SerializeField] GameObject laser;


    float timer;

    private void Awake()
    {
        timer = damageDelay;
        laser.SetActive(true);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            FrameShoot();
            timer = damageDelay;
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
}
