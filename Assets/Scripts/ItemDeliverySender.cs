using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDeliverySender : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [HideInInspector] public bool HasBeenFinished = false;
    [HideInInspector] public bool HasBeenStarted = false;
    public InventoryItem ItemToDeliver;
    public void StartQuest()
    {
        if(ItemToDeliver != null && HasBeenFinished == false && HasBeenStarted == false)
        {
            if(inventory.AddToInventory(ItemToDeliver))
            {
                HasBeenStarted = true;
                Debug.Log("ITEM DELIVER SENT BEGAN");
            }
            else
            {
                Debug.Log("HAS NO SPACE");
            }
        }
    }
}
