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
    }
}
