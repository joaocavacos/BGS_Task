using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public int itemBuyPrice;
    public int itemSellPrice;
    public Sprite itemIcon;
    public bool isEquipable;
    public RuntimeAnimatorController outfitAnimator;
}
