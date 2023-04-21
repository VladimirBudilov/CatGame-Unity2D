using System.Collections;
using System.Collections.Generic;
using _Scripts.Quests;
using TMPro;
using UnityEngine;

public class QuestItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI progress;
    private QuestStatus status;
        

    public void Setup(QuestStatus status)
    {
        this.status = status;
        title.text = status.Quest.GetTitle();
        progress.text = status.GetCompletedCount() + "/" + status.Quest.GetObjectiveCount();
    }

    public QuestStatus GetQuestStatus()
    {
        return status;
    }
}
