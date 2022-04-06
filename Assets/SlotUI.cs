using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]

public class SlotUI : MonoBehaviour
{
    public ItemType slotType;
    public Image image;
    public ItemUI item;


    public bool Add(ItemUI Item)
    {
        if(Item == null)
        {
            item = Item;
            return true;
        }
        return false;
    }

    public void Clear()
    {
        item = null;
    }


    private void OnMouseDown()
    {
        Debug.Log("Test");
    }


    private void OnMouseUp()
    {
        
    }


}
