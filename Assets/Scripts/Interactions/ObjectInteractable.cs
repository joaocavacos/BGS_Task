using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectInteractable : MonoBehaviour, IInteractable
{
    public UnityEvent OnPlayerInteract;
    
    public void Interact()
    {
        print("Object interact");
        OnPlayerInteract?.Invoke();
    }
}
