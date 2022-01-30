using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;

    public string questTitle;
    public string questDescription;
    public int pointsText;

    public QuestGoal goal;

    public void Complete()
    {
        isActive = false;
        Debug.Log(questTitle + "was completed.");

        switch (goal.goalType)
        {
            case GoalType.Assassin:
                break;
            case GoalType.CrazyTaxi:
                GameObject.Find("Pedestrian_Waving")?.SetActive(false);
                GameObject.Find("PlayerManager")?.GetComponent<PlayerManager>()?.SetAsActivePlayer("FirstPersonPlayer");
                break;
            case GoalType.Fishing:
                GameObject.Find("Pedestrian_Sitting 1")?.SetActive(false);
                break;
            case GoalType.Unpacking:
                GameObject.Find("Pedestrian_Sitting 2")?.SetActive(false);
                GameObject.Find("TELEPORT DOOR")?.SetActive(false);
                break;
            case GoalType.Hacker:
                break;
            case GoalType.Delivery:
                break;
            default:
                break;
        }
    }
}
