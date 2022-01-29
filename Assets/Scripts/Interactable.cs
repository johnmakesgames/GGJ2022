using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnInteractionEvent;

    public void Awake()
    {
      
    }

    [HideInInspector]
    public void Interact()
    {
        OnInteractionEvent.Invoke();
    }

    public void OnDestroy()
    {
        OnInteractionEvent.RemoveAllListeners();
    }

    
}
