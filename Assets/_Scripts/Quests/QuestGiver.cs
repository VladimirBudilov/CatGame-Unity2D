using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    private Quest quest;
    [SerializeField] private bool questFinished = false;

    public void GiveQuest(Quest newQuest)
    {
        if(questFinished) return;
        var quests = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestList>();
        this.quest = newQuest;
        quests.AddQuest(newQuest);
    }

    public void RemoveQuest()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<QuestList>().RemoveQuest(quest);
        questFinished = true;
    }
}
