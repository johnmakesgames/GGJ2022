using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckpointSystem : MonoBehaviour
{
    [SerializeField]
    GameObject[] Checkpoints;

    [SerializeField]
    GameObject player;

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
    }
    private void Awake()
    {
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
            player.GetComponent<MoralityTracker>().SignalActivityCompleted();
        }
        else
        {
            //wrong
        }

        if (NextCheckpointIndex < SingleCheckPointList.Count)
        {
            Checkpoints[NextCheckpointIndex].SetActive(true);
        }
        else
        {
            player.SetActive(true);
        }
    }
}
