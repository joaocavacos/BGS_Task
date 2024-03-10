using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInterface : MonoBehaviour
{
    public TMP_Text moneyText;

    private void OnEnable()
    {
        CurrencyManager.OnMoneyAmountChanged += UpdateMoneyText;
    }

    private void OnDisable()
    {
        CurrencyManager.OnMoneyAmountChanged -= UpdateMoneyText;
    }

    private void Start()
    {
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        moneyText.text = CurrencyManager.Instance.GetMoney().ToString();
    }
    
    
}
