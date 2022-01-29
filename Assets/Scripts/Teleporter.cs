using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{

    public Transform teleportTargert;
    public GameObject playerObject;
    [SerializeField] private Image teleporterUI;

    // Start is called before the first frame update
    void Start()
    {
        teleporterUI.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        teleporterUI.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        teleporterUI.enabled = false;
    }



    public void ActivateTeleport()
    {
        playerObject.GetComponent<CharacterController>().enabled = false;
        playerObject.transform.position = teleportTargert.transform.position;
        playerObject.GetComponent<CharacterController>().enabled = true;
    }
}
