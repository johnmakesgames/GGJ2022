using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    

    public MoralityTracker player;

    public GameObject questWindow;
    public Text tilteText;
    public Text descriptionText;
    public Text pointsText;

    public bool questPending = false;

    public QuestGoal questGoal;
    public GameObject setQuestTarget;

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        tilteText.text = quest.questTitle;
        descriptionText.text = quest.questDescription;
        pointsText.text = quest.pointsText.ToString();
        questPending = true;

    }

    private void Update()
    {
        if (quest.isActive == false && questPending == true)
        {
            AcceptQuest();
        }
        
    }
    public void AcceptQuest()
    {
       
            if (Input.GetKeyDown(KeyCode.Space))
            {
                questWindow.SetActive(false);
                quest.isActive = true;
                player.currentQuest = quest;
                questPending = false;
                questGoal.setTarget = setQuestTarget; 
            }
        
    }
        
        
        
    
}
