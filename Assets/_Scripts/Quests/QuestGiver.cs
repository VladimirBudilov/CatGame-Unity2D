using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private Quest quest;
    [SerializeField] private bool questFinished = false;

    public void GiveQuest()
    {
        if(questFinished) return;
        var quests = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestList>();
        quests.AddQuest(quest);
    }

    public void RemoveQuest()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<QuestList>().RemoveQuest(quest);
        questFinished = true;
    }
}
