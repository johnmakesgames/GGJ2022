using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    [SerializeField] GameObject Checkpoint1;
    [SerializeField] GameObject Checkpoint2;
    [SerializeField] GameObject Checkpoint3;
    [SerializeField] GameObject Checkpoint4;
    [SerializeField] GameObject Checkpoint5;

    
    
    
    

    private List<SingleCheckpoint> SingleChedckpointList;
    private int NextCheckpointIndex;


    private void Start()
    {
        Checkpoint1.SetActive(true);
        Checkpoint2.SetActive(false);
        Checkpoint3.SetActive(false);
        Checkpoint4.SetActive(false);
        Checkpoint5.SetActive(false);
    }
    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");


        SingleChedckpointList = new List<SingleCheckpoint>();
        foreach (Transform SingleCheckpointTransform in checkpointsTransform)
        {
            SingleCheckpoint singleCheckpoint = SingleCheckpointTransform.GetComponent<SingleCheckpoint>();
            singleCheckpoint.SetCheckpoint(this);
            SingleChedckpointList.Add(singleCheckpoint);
        }

        NextCheckpointIndex = 0;
    }

    public void PlayerThroughCheckpoint(SingleCheckpoint singleCheckpoint)
    {
        if(SingleChedckpointList.IndexOf(singleCheckpoint) == NextCheckpointIndex)
        {
            //correct checkpoint

            NextCheckpointIndex = (NextCheckpointIndex + 1) % SingleChedckpointList.Count;
        }
        else
        {
            //wrong
        }
        if (NextCheckpointIndex == 0)
        {
            
            Checkpoint1.SetActive(true);
        }
        if (NextCheckpointIndex == 1)
        {
            Checkpoint1.SetActive(false);
            Checkpoint2.SetActive(true);
            
        }
        if (NextCheckpointIndex == 2)
        {
            Checkpoint2.SetActive(false);
            Checkpoint3.SetActive(true);
        }
        if (NextCheckpointIndex == 3)
        {
            Checkpoint3.SetActive(false);
            Checkpoint4.SetActive(true);
        }
        if (NextCheckpointIndex == 4)
        {
            Checkpoint4.SetActive(false);
            Checkpoint5.SetActive(true);
        }
        
    }
}
