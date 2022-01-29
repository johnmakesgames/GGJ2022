using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{

    public Transform teleportTarget;
    public GameObject playerObject;
    public GameObject checkObject;

    [SerializeField] private Text teleportToRoof;
    [SerializeField] private Text teleportToGround;


    private void OnTriggerEnter(Collider other)
    {

        if(checkObject.CompareTag("groundfloorTeleporter"))
        {
            teleportToRoof.enabled = true;
        }
        else if(checkObject.CompareTag("roofTeleporter"))
        {
            teleportToGround.enabled = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (checkObject.CompareTag("groundfloorTeleporter"))
        {
            teleportToRoof.enabled = false;
        }
        else if (checkObject.CompareTag("roofTeleporter"))
        {
            teleportToGround.enabled = false;
        }
    }



    public void ActivateTeleport()
    {
        playerObject.GetComponent<CharacterController>().enabled = false;
        playerObject.transform.position = teleportTarget.transform.position;
        playerObject.GetComponent<CharacterController>().enabled = true;
    }
}
