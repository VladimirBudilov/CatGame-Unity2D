using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
public class QuestCompletion : MonoBehaviour
{
    [SerializeField] Quest quest;
    [SerializeField] string objective;

    public void CompleteObjective()
    {
        QuestList questList = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestList>();
        questList.CompleteObjective(quest, objective);
    }
    public void AddCompletedObjective(string objective)
    {
        Debug.Log(objective);
        this.objective = objective;
        Debug.Log(this.objective);

    }
}
