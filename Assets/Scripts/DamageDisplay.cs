using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class DamageDisplay : MonoBehaviour
{
    [SerializeField] TextMesh damageText;

    public void DisplayDamage(float damage)
    {
        TextMesh newDamageText = Instantiate(damageText, transform.position, Quaternion.identity);
        newDamageText.text = damage.ToString();
    }
}
