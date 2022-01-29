using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCheckpoint : MonoBehaviour
{
    private CheckpointSystem CheckpointSystem;

    private void OnCollisionEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerInteraction>(out PlayerInteraction player))
            {
            CheckpointSystem.PlayerThroughCheckpoint(this);
        }
       
           
      
    }

    public void SetCheckpoint(CheckpointSystem checkpointSystem)
    {
        this.CheckpointSystem = checkpointSystem;
    }
}
