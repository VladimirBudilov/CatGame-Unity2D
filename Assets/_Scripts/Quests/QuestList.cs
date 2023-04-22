using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Quests;
using Unity.VisualScripting;
using UnityEngine;

public class  QuestList : MonoBehaviour
{
    private List<QuestStatus> statuses = new List<QuestStatus>();
    public event Action onQuestUpdated;


    public IEnumerable<QuestStatus> GetStatuses()
    {
        return statuses;
    }

    public void AddQuest(Quest quest)
    {
        if(HasQuest(quest)) return;
        var newStatus = new QuestStatus(quest);
        statuses.Add(newStatus);
        onQuestUpdated?.Invoke();
    }

    private bool HasQuest(Quest quest)
    {
        return GetQuestStatus(quest) != null;
    }

    public void CompleteObjective(Quest quest, string objectives)
    {
        var status = GetQuestStatus(quest);
        status.CompleteObjective(objectives);
        onQuestUpdated?.Invoke();

    }

    private QuestStatus GetQuestStatus(Quest quest)
    {
        foreach (var status in statuses)
        {
            if(status.Quest == quest) return status;
        }
        return null;
    }
}
