using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInterface : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    public Transform slots;
    public Transform itemSlotTemplate;
    public Transform outfitGO;
    public Animator outfitAnimator;
    [HideInInspector] public bool IsOpen;

    void Start()
    {
        Hide();
    }

    private void CreateItems()
    {
        List<InventoryItem> inventoryItems = _inventory.inventory;

        foreach (var item in inventoryItems)
        {
            CreateItemSlot(item.itemSO, item.quantity);
        }
    }

    public void DestroyItems()
    {
        foreach (Transform child in slots)
        {
            Destroy(child.gameObject);
        }
    }
    
    private void CreateItemSlot(ItemSO itemData, int quantity)
    {
        Transform itemTransform = Instantiate(itemSlotTemplate, slots);
        itemTransform.gameObject.SetActive(true);
        
        itemTransform.Find("Icon").GetComponent<Image>().sprite = itemData.itemIcon;
        itemTransform.Find("Quantity").GetComponent<TMP_Text>().SetText(quantity.ToString());
        var equipBtn = itemTransform.Find("EquipBtn").GetComponent<Button>();
        
        if (itemData.isEquipable)
        {
            equipBtn.onClick.AddListener(() => EquipOutfit(itemData));
        }
        else
        {
            equipBtn.gameObject.SetActive(false);
        }
        
    }

    private void EquipOutfit(ItemSO itemData)
    {
        outfitAnimator.runtimeAnimatorController = itemData.outfitAnimator;
        outfitGO.gameObject.SetActive(true);
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
        IsOpen = true;
        CreateItems();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        IsOpen = false;
    }
}
