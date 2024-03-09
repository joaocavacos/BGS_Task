using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopInterface : MonoBehaviour
{
    private Transform container;
    private Transform itemTemplate;

    public List<ItemSO> itemsToBuy;

    private void Awake()
    {
        container = transform.Find("Container");
        itemTemplate = container.Find("ShopItemTemplate");
        itemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        for (int i = 0; i < itemsToBuy.Count; i++)
        {
            CreateBuyItemButton(itemsToBuy[i], i);
        }
        
        Hide();
    }

    private void CreateBuyItemButton(ItemSO itemData, int posIndex)
    {
        Transform itemTransform = Instantiate(itemTemplate, container);
        itemTransform.gameObject.SetActive(true);
        RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();

        var shopItemHeight = 150f;
        itemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * posIndex);
        
        itemTransform.Find("ItemName").GetComponent<TMP_Text>().SetText(itemData.itemName);
        itemTransform.Find("ItemPrice").GetComponent<TMP_Text>().SetText(itemData.itemBuyPrice.ToString());
        itemTransform.Find("ItemIcon").GetComponent<Image>().sprite = itemData.itemIcon;
        
        var itemBtn = itemTransform.GetComponent<Button>();
        itemBtn.onClick.AddListener(() => TryBuyItem(itemData));

    }

    private void TryBuyItem(ItemSO itemData)
    {
        if (CurrencyManager.Instance.TrySpendGold(itemData.itemBuyPrice))
        {
            CurrencyManager.Instance.BuyItem(itemData);
        }
        else
        {
            print("Can't afford item");
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
}
