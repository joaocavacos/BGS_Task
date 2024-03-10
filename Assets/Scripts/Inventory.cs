using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();
    private Dictionary<ItemSO, InventoryItem> _itemDictionary = new Dictionary<ItemSO, InventoryItem>();

    [Space, SerializeField] private InventoryInterface _inventoryInterface;
    public KeyCode inventoryOpenKeycode;

    private void Update()
    {
        if (Input.GetKeyDown(inventoryOpenKeycode) && !_inventoryInterface.IsOpen)
        {
            OpenInventory();
        }
    }

    public void AddItem(ItemSO itemData)
    {
        if(_itemDictionary.TryGetValue(itemData, out InventoryItem item)) //Inventory has this item? Increase quantity
        {
            item.AddItemQuantity();
        }
        else //else, add new item to inventory
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            _itemDictionary.Add(itemData, newItem);
        }
    }

    public void RemoveItem(ItemSO itemData)
    {
        if(_itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveItemQuantity();

            if (item.quantity == 0)
            {
                inventory.Remove(item);
                _itemDictionary.Remove(itemData);
            }
        }
    }

    private void OpenInventory()
    {
        _inventoryInterface.Show();
    }
    
}
