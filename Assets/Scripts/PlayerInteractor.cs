using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private IInteractable _interactable;
    [SerializeField] private KeyCode interactKey;
    
    private void Update()
    {
        if (_interactable == null) return;
        
        if (Input.GetKeyDown(interactKey))
        {
            _interactable.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable newInteractable))
        {
            _interactable = newInteractable;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _interactable = null;
    }
}
