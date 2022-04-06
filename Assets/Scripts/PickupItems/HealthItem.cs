using UnityEngine;

public class HealthItem : PickupItem
{
    [SerializeField] float healthAmount;

    public override void PickUp(GameObject player)
    {
        player.GetComponent<Health>().Heal(healthAmount);
        base.PickUp(player);
    }
}
