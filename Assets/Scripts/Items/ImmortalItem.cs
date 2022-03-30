using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmortalItem : PickupItem
{
    [SerializeField] float immortalTime = 5f;
    public override void PickUp(GameObject player)
    {
        player.GetComponent<Health>().ImmortalTimer(immortalTime);
        base.PickUp(player);
    }
}
