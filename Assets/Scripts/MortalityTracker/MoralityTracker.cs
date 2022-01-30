using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoralityTracker : MonoBehaviour
{
    public int goodBoyPoints = 0;
    public int badBoyPoints = 0;

    public Quest currentQuest;

   public void DoQuest()
    {
        if (currentQuest.isActive)
        {
            currentQuest.goal.EnemyKilled();
            if (currentQuest.goal.IsReached())
            {
                goodBoyPoints += currentQuest.pointsText;
            }

        }
    }

    

}
