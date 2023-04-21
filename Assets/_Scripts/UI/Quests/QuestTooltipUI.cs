using System.Collections;
using System.Collections.Generic;
using _Scripts.Quests;
using TMPro;
using UnityEngine;

public class QuestTooltipUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Transform objectiveContainer;
    [SerializeField] private GameObject objectivePref;
    [SerializeField] private GameObject objectiveIncompletePref;
    
    
    public void Setup(QuestStatus status)
    {
       
        title.text = status.Quest.GetTitle();
        objectiveContainer.DetachChildren();
        foreach (var objective in status.Quest.GetObjectives())
        {
            GameObject pref = status.IsObjectiveCompleted(objective) ? objectivePref : objectiveIncompletePref; 
            var newObjective = Instantiate(pref, objectiveContainer);
            newObjective.GetComponentInChildren<TextMeshProUGUI>().text = objective;
        }
        
    }
}
