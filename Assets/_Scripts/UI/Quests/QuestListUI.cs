using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestListUI : MonoBehaviour
{
    [SerializeField] GameObject questItemPref;
    private QuestList quests;
    void Start()
    {
        quests = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestList>();
        UpdateUI();
        quests.onQuestUpdated += UpdateUI;
    }

    private void UpdateUI()
    {
        transform.DetachChildren();
        quests = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestList>();
        foreach (var status in quests.GetStatuses())
        {
            var newQuest = Instantiate(questItemPref, transform);
            newQuest.GetComponent<QuestItemUI>().Setup(status);
        }
    }
}
