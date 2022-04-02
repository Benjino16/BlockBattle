using UnityEngine;

public class CoinItem : PickupItem
{
    [SerializeField] int coinAmount;
    public override void PickUp(GameObject player)
    {
        GameManager.Instance.coins += coinAmount;
        base.PickUp(player);
    }
}
