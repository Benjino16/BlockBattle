using UnityEngine;

public class Boss2AI : MonoBehaviour
{

    [Header("Boss 2 Settings:")]
    [SerializeField] float acceleration = 1f;
    [SerializeField] float finalTurnspeed = 10f;
    [SerializeField] float healtLaser2 = 50f;
    [SerializeField] float healthLaser3 = 25f;

    private float turnSpeed = 0f;




    [Space]
    [Header("Required Components:")]
    [SerializeField] Health health;
    [SerializeField] GameObject laser1;
    [SerializeField] GameObject laser2;
    [SerializeField] GameObject laser3;

    [Space]
    [Header("Sprite Components:")]
    [SerializeField] Sprite laserOffSprite;
    [SerializeField] Sprite laser1Sprite;
    [SerializeField] Sprite laser2Sprite;
    [SerializeField] Sprite laser3Sprite;


    bool active = false;


    void Update()
    {
        if (turnSpeed < finalTurnspeed)
        {
            turnSpeed += acceleration * Time.deltaTime;
        }


        if (active)
        {
            transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }

        if (health.health / health.maxHealth < healthLaser3)
        {
            ActivateLaser(3);
        }
        else if (health.health / health.maxHealth < healtLaser2)
        {
            ActivateLaser(2);
        }
        else if (health.health < health.maxHealth)
        {
            ActivateLaser(1);
        }
        else
        {
            ActivateLaser(0);
        }
    }

    private void ActivateLaser(int number)
    {
        active = true;
        if (number == 0)
        {
            GetComponent<SpriteRenderer>().sprite = laserOffSprite;
            laser1.SetActive(false);
            laser2.SetActive(false);
            laser3.SetActive(false);
            active = false;
        }
        else if (number == 1)
        {
            GetComponent<SpriteRenderer>().sprite = laser1Sprite;
            laser1.SetActive(true);
            laser2.SetActive(false);
            laser3.SetActive(false);
        }
        else if (number == 2)
        {
            GetComponent<SpriteRenderer>().sprite = laser2Sprite;
            laser1.SetActive(false);
            laser2.SetActive(true);
            laser3.SetActive(false);
        }
        else if (number == 3)
        {
            GetComponent<SpriteRenderer>().sprite = laser3Sprite;
            laser1.SetActive(false);
            laser2.SetActive(false);
            laser3.SetActive(true);
        }
    }
}
