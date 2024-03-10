using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopInterface : MonoBehaviour
{
    private Transform container;
    private Transform initialButtons;
    [SerializeField] private Transform itemBuyTemplate;
    [SerializeField] private Transform itemSellTemplate;

    [SerializeField] private List<ItemSO> stockItemsToBuy;
    [SerializeField] private Inventory playerInventory; 

    private void Awake()
    {
        container = transform.Find("Container");
        initialButtons = transform.Find("InitialButtons");
    }

    private void Start()
    {
        Hide();
    }

    public void CreateBuyItems() //Creates all of the items that are on stock to buy
    {
        for (int i = 0; i < stockItemsToBuy.Count; i++)
        {
            CreateBuyItemButton(stockItemsToBuy[i], i);
        }
    }

    public void CreateSellItems() //Creates all of the items that are sellable on the player's inventory
    {
        List<InventoryItem> inventory = playerInventory.inventory;
        
        for (int i = 0; i < inventory.Count; i++)
        {
            CreateSellItemButton(inventory[i].itemSO, inventory[i].quantity, i);
        }
    }

    public void DestroyItemButtons() //Destroys buy/sell buttons on shop close
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
    }

    private void CreateBuyItemButton(ItemSO itemData, int posIndex) //All the necessary stuff to create a buy button
    {
        Transform itemTransform = Instantiate(itemBuyTemplate, container);
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

    private void CreateSellItemButton(ItemSO itemData, int quantity, int posIndex) //All the necessary stuff to create a sell button
    {
        Transform itemTransform = Instantiate(itemSellTemplate, container);
        itemTransform.gameObject.SetActive(true);
        RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();

        var shopItemHeight = 150f;
        itemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * posIndex);
        
        itemTransform.Find("ItemName").GetComponent<TMP_Text>().SetText(itemData.itemName);
        itemTransform.Find("ItemPrice").GetComponent<TMP_Text>().SetText(itemData.itemSellPrice.ToString());
        itemTransform.Find("ItemQuantity").GetComponent<TMP_Text>().SetText(quantity.ToString());
        itemTransform.Find("ItemIcon").GetComponent<Image>().sprite = itemData.itemIcon;
        
        var itemBtn = itemTransform.GetComponent<Button>();
        itemBtn.onClick.AddListener(() => TrySellItem(itemData));
    }

    private void TryBuyItem(ItemSO itemData) //Checks for gold and buys if it's possible
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

    private void TrySellItem(ItemSO itemData) //Sells and updates quantity to check if can be sold
    {
        CurrencyManager.Instance.SellItem(itemData);
        UpdateSellItems();
    }

    private void UpdateSellItems()
    {
        DestroyItemButtons();
        CreateSellItems();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        initialButtons.gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        initialButtons.gameObject.SetActive(false);
    }
    
}
