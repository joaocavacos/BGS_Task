using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public ItemSO itemSO;
    public int quantity;

    public InventoryItem(ItemSO itemData)
    {
        itemData = itemSO;
        AddItemQuantity();
    }

    public void AddItemQuantity()
    {
        quantity++;
    }

    public void RemoveItemQuantity()
    {
        quantity--;
    }
}
