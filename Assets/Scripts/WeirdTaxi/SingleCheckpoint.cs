using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCheckpoint : MonoBehaviour
{
    private CheckpointSystem CheckpointSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CarController>())
        {
            CheckpointSystem.PlayerThroughCheckpoint(this);
        }
    }

    public void SetCheckpoint(CheckpointSystem checkpointSystem)
    {
        this.CheckpointSystem = checkpointSystem;
    }
}
