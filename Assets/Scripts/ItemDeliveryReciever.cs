using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDeliveryReciever : MonoBehaviour
{
    public ItemDeliverySender QuestStarter;
    [SerializeField] private PlayerInventory inventory;

    public void EndQuest()
    {
        if(inventory != null)
        {
            if(QuestStarter.HasBeenStarted)
            {
                if (inventory.IsInInventory(QuestStarter.ItemToDeliver))
                {
                    Debug.Log("Item has been attempted to be delivered.");
                    if(inventory.RemoveFromInventory(QuestStarter.ItemToDeliver))
                    {
                        Debug.Log("QUEST FINISHED");
                        QuestStarter.HasBeenFinished = true;
                        inventory.gameObject.GetComponent<MoralityTracker>().SignalActivityCompleted();
                    }
                    else
                    {
                        Debug.Log("Failed to remove item from inventory.");
                    }
                }
                else
                {
                    Debug.Log("Quest has been started but they've not got the item?");
                }
            }
            else
            {
                Debug.Log("Qeust hasnt been started yet.");
            }

        }
    }
}
