using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public InventoryItem testItem;

    public bool CanInteractWithOthers = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Interact") && CanInteractWithOthers)
        {
            Debug.Log("interact cast");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("interact cast");
            if (Physics.Raycast(ray, out hit, 20.0f))
            {
                Debug.DrawLine(ray.origin, hit.point);
                Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();

                if(interactable != null)
                {
                    interactable.TriggerInteraction();
                }
            }        
        }
    }


    public void TestInventory()
    {
        if(GetComponent<PlayerInventory>().AddToInventory(testItem))
        {
            Debug.Log("ITEM ADDED");
        }
        else
        {
            Debug.Log("ITEM NOT ADDED");
        }    
    }

    public void SetCanInteract(bool state)
    {
        CanInteractWithOthers = state;
    }

    public void ToggleIfCanInteract()
    {
        CanInteractWithOthers = !CanInteractWithOthers;
    }
}
