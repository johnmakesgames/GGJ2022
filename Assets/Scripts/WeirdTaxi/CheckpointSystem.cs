using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckpointSystem : MonoBehaviour
{
    //[SerializeField] GameObject Checkpoint1;
    //[SerializeField] GameObject Checkpoint2;
    //[SerializeField] GameObject Checkpoint3;
    //[SerializeField] GameObject Checkpoint4;
    //[SerializeField] GameObject Checkpoint5;

    [SerializeField]
    GameObject[] Checkpoints;

    private List<SingleCheckpoint> SingleCheckPointList;
    private int NextCheckpointIndex;
    public Text CheckpointNumber;



    private void Start()
    {
        SingleCheckPointList = new List<SingleCheckpoint>();
        foreach (var checkpoint in Checkpoints)
        {
            checkpoint.SetActive(false);
            SingleCheckPointList.Add(checkpoint.GetComponent<SingleCheckpoint>());
            checkpoint.GetComponent<SingleCheckpoint>().SetCheckpoint(this);
        }

        Checkpoints[0].SetActive(true);

        //Checkpoint1.SetActive(true);
        //Checkpoint2.SetActive(false);
        //Checkpoint3.SetActive(false);
        //Checkpoint4.SetActive(false);
        //Checkpoint5.SetActive(false);
    }
    private void Awake()
    {
        //Transform checkpointsTransform = transform.Find("Checkpoints");

        //SingleChedckpointList = new List<SingleCheckpoint>();
        //foreach (Transform SingleCheckpointTransform in checkpointsTransform)
        //{
        //    SingleCheckpoint singleCheckpoint = SingleCheckpointTransform.GetComponent<SingleCheckpoint>();
        //    singleCheckpoint.SetCheckpoint(this);
        //    SingleChedckpointList.Add(singleCheckpoint);
        //}

        NextCheckpointIndex = 0;
    }

    public void PlayerThroughCheckpoint(SingleCheckpoint singleCheckpoint)
    {
        Checkpoints[NextCheckpointIndex].SetActive(false);

        if(SingleCheckPointList.IndexOf(singleCheckpoint) == NextCheckpointIndex)
        {
            //correct checkpoint
            NextCheckpointIndex = (NextCheckpointIndex + 1);
            CheckpointNumber.text = $"{NextCheckpointIndex}/{SingleCheckPointList.Count}";
        }
        else
        {
            //wrong
        }

        Checkpoints[NextCheckpointIndex].SetActive(true);

        //if (NextCheckpointIndex == 0)
        //{

        //    Checkpoint1.SetActive(true);
        //}
        //if (NextCheckpointIndex == 1)
        //{
        //    Checkpoint1.SetActive(false);
        //    Checkpoint2.SetActive(true);

        //}
        //if (NextCheckpointIndex == 2)
        //{
        //    Checkpoint2.SetActive(false);
        //    Checkpoint3.SetActive(true);
        //}
        //if (NextCheckpointIndex == 3)
        //{
        //    Checkpoint3.SetActive(false);
        //    Checkpoint4.SetActive(true);
        //}
        //if (NextCheckpointIndex == 4)
        //{
        //    Checkpoint4.SetActive(false);
        //    Checkpoint5.SetActive(true);
        //}

    }
}
