using System.Collections;
using System.Collections.Generic;
using _Scripts.NPC_s;
using UnityEngine;
using UnityEngine.Serialization;

public class Baker : MonoBehaviour
{
    [SerializeField] private string bread = "Bread";
    [SerializeField] private string bugSpray = "Spray";

    public void GiveBread()
    {
        GetComponent<QuestCompletion>().AddCompletedObjective(bread);
        GameObject.FindGameObjectWithTag("Player").GetComponent<CatInventory>().GetItem(bread);
        GetComponent<QuestCompletion>().CompleteObjective();
    }
    
    public void GiveBugSpray()
    {
        GetComponent<QuestCompletion>().AddCompletedObjective(bugSpray);
        GameObject.FindGameObjectWithTag("Player").GetComponent<CatInventory>().GetItem(bugSpray);
        GetComponent<QuestCompletion>().CompleteObjective();
    }
}
