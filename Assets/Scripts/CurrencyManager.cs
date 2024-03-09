using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class CurrencyManager : Singleton<CurrencyManager>
{
    private int currentMoney;

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

    public int GetMoney()
    {
        return currentMoney;
    }
    
}
