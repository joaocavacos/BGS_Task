using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class CurrencyManager : Singleton<CurrencyManager>
{
    [SerializeField] private int currentMoney;
    [SerializeField] private Inventory _inventory;
    public static event Action OnMoneyAmountChanged;
    
    public void AddMoney(int amount)
    {
        currentMoney += amount;
        OnMoneyAmountChanged?.Invoke();
    }

    public void RemoveMoney(int amount)
    {
        currentMoney -= amount;
        OnMoneyAmountChanged?.Invoke();
    }

    public void BuyItem(ItemSO itemData)
    {
        RemoveMoney(itemData.itemBuyPrice);
        _inventory.AddItem(itemData);
    }

    public void SellItem(ItemSO itemData)
    {
        AddMoney(itemData.itemSellPrice);
        _inventory.RemoveItem(itemData);
    }

    public bool TrySpendGold(int itemPriceAmount)
    {
        return GetMoney() >= itemPriceAmount;
    }

    public int GetMoney()
    {
        return currentMoney;
    }
    
}
