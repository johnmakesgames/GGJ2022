using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var controller = other.GetComponent<CharacterController>();
            if (controller)
                controller.enabled = false;

            other.transform.position = new Vector3(0, 0, 0);

            if (controller)
                controller.enabled = true;
        }
    }
}
