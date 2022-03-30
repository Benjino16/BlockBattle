using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : PickupItem
{
    [SerializeField] float shieldAmount = 20f;
    public override void PickUp(GameObject player)
    {
        player.GetComponent<Health>().AddShield(shieldAmount);
        base.PickUp(player);
    }
}
