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
    public void TriggerInteraction()
    {
        Debug.Log("Trigger Interaction");
        OnInteractionEvent.Invoke();
    }

    public void OnDestroy()
    {
        OnInteractionEvent.RemoveAllListeners();
    }

    
}
