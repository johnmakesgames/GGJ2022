using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public int requiredAmount;
    public int currentAmount;
    public GameObject setTarget;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void EnemyKilled()
    {
        if (goalType == GoalType.Assassin) 
        {
            if (setTarget.CompareTag("AssassinTarget"))
            {
                currentAmount++;
            }
        }        
    }

    public void TaxiMission()
    {
        if (goalType == GoalType.CrazyTaxi)
        {
            currentAmount++;
        }

    }
    
}

public enum GoalType
{
    Assassin,
    CrazyTaxi,
    Fishing,
    Unpacking,
    Hacker,
    Delivery

}