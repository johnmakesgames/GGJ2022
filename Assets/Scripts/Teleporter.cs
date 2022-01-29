using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public Transform teleportTargert;
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateTeleport()
    {
        playerObject.GetComponent<CharacterController>().enabled = false;
        playerObject.transform.position = teleportTargert.transform.position;
        playerObject.GetComponent<CharacterController>().enabled = true;
    }
}
