using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestListUI : MonoBehaviour
{
    [SerializeField] GameObject questItemPref;
    
    void Start()
    {
        transform.DetachChildren();
        var quests = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestList>();
        foreach (var status in quests.GetStatuses())
        {
            var newQuest = Instantiate(questItemPref, transform);
            newQuest.GetComponent<QuestItemUI>().Setup(status);
        }
        
    }
}
