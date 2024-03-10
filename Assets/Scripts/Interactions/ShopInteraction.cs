using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private ShopInterface shopUI;

    public void Interact()
    {
        shopUI.Show();
    }
}
