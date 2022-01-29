using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float InteractionDistance;
    public bool CanInteractWithOthers = true;

    // Start is called before the first frame update
    void Start()
    {
        if(InteractionDistance == 0.0f)
        {
            InteractionDistance = 15.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && CanInteractWithOthers)
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, InteractionDistance))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.green);
                Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();

                if(interactable != null)
                {
                    interactable.Interact();
                }
            }        
            else
            {
                Debug.DrawLine(ray.origin, ray.origin + (ray.direction.normalized * InteractionDistance), Color.red);
            }
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
