using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class QuestCompletion : MonoBehaviour
{
    [SerializeField] private Quest _quest;
    [SerializeField]  private string objective = "";

    public void CompleteObjective()
    {
        var questList = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestList>();
        questList.CompleteObjective(_quest, objective);
    }

    public void AddCompletedObjective(string objective)
    {
        this.objective = objective;
    }
    
    
    
    
}
