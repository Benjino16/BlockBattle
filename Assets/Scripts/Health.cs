using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    public float shield = 0f;
    [SerializeField] float immortalTimer = 0f;

    [SerializeField] Rigidbody2D knockbackRB;
    [SerializeField] float knockback;


    bool immortal = false;

    public void Heal(float value)
    {
        health += value;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void AddShield(float value)
    {
        shield += value;
        if (shield > maxHealth)
        {
            shield = maxHealth;
        }
    }

    public void Damage(float damage, GameObject attacker, Vector2? direction = null)
    {
        if (!immortal)
        {
            if(GetComponent<DamageDisplay>() != null)
            {
                GetComponent<DamageDisplay>().DisplayDamage(damage);
            }
            shield -= damage;
            if (shield < 0)
            {
                health += shield;
                shield = 0f;
            }

            if (knockbackRB != null && direction != null)
            {
                knockbackRB.AddForce((knockbackRB.position - direction.Value) * knockback);
                Debug.Log("Applied " + knockback + " knockback to " + gameObject.name);
            }

            if (health <= 0)
            {
                health = 0f;
                Die(attacker);
            }
        }
    }

    private void Immortal(bool status)
    {
        if (status != immortal)
        {
            if (status)
            {
                immortal = true;
                Debug.Log(gameObject.name + " is now immortal");
            }
            else
            {
                immortal = false;
                immortalTimer = 0f;
                Debug.Log(gameObject.name + " is not longer immortal");
            }
        }
    }

    public void ImmortalTimer(float timeInSeconds)
    {
        immortalTimer = timeInSeconds;
    }

    private void Die(GameObject attacker)
    {
        if (CompareTag("Player"))
        {
            GameManager.Instance.EndGame(false);
        }
        else if (CompareTag("Boss"))
        {
            GameManager.Instance.EndGame(true);
        }

        if (attacker == null)
        {
            attacker = new GameObject { name = "destroyed gameobject" };
        }
        Debug.Log(gameObject.name + " died by " + attacker.name);
        Destroy(gameObject);
    }

    private void Update()
    {
        immortalTimer -= Time.deltaTime;
        if (immortalTimer > 0f)
        {
            Immortal(true);
        }
        else
        {
            Immortal(false);
        }
    }
}
