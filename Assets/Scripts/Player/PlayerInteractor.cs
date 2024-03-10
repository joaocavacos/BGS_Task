using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private IInteractable _interactable;
    private Animator playerAnimator;
    
    [SerializeField] private KeyCode interactKey;

    private void Start()
    {
        playerAnimator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        SetInteractionDirection();
        
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

    private void SetInteractionDirection()
    {
        var lastMoveX = playerAnimator.GetFloat("lastMoveX");
        var lastMoveY = playerAnimator.GetFloat("lastMoveY");

        switch (lastMoveX)
        {
            case >= 1f:
                transform.localPosition = new Vector3(0, 0.7f, 0);
                break;
            case <= -1f:
                transform.localPosition = new Vector3(0, -0.7f, 0);
                break;
        }
        switch (lastMoveY)
        {
            case >= 1f:
                transform.localPosition = new Vector3(0.5f, 0, 0);
                break;
            case <= -1f:
                transform.localPosition = new Vector3(-0.5f, 0, 0);
                break;
        }
        
    }
}
