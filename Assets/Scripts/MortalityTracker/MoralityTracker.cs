using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoralityTracker : MonoBehaviour
{
    public int goodBoyPoints = 0;
    public int badBoyPoints = 0;

    public Quest currentQuest;

    public void CompleteGoodTask()
    {
        goodBoyPoints += 1;
    }

    public void CompletedBadTask()
    {
        badBoyPoints += 1;
    }



}
