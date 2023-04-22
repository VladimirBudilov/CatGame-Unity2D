using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Baker : MonoBehaviour
{
    [SerializeField] private string bread = "bread";
    [SerializeField] private string bugSpray = "bread";
    bool breadWasGiven = false;
    bool bugSprayWasGiven = false;
    
    public void GiveBread()
    {
        if(breadWasGiven) return;
        GetComponent<QuestCompletion>().AddCompletedObjective(bread);
        GetComponent<QuestCompletion>().CompleteObjective();
        Debug.Log("bread Added");
        breadWasGiven = true;
    }
    
    public void GiveBugSpray()
    {
        if(bugSprayWasGiven) return;
        GetComponent<QuestCompletion>().AddCompletedObjective(bugSpray);
        GetComponent<QuestCompletion>().CompleteObjective();
        Debug.Log("bugSpray Added");
        bugSprayWasGiven = true;
    }
}
