using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PickUp(collision.gameObject);
        }
    }

    public virtual void PickUp(GameObject player)
    {
        Debug.Log("Player picked up " + gameObject.name);
        Destroy(gameObject);
    }
}
