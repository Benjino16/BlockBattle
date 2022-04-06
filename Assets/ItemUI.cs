using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New UI Item", menuName = "ItemUI")]
public class ItemUI : ScriptableObject
{
    public ItemType itemType;
    public Image itemImage;
    public Image leftItemImage;


    
}

public enum ItemType
{
    Weapon,
    Ability
}
