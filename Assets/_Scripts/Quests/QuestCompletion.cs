using UnityEngine;

public class QuestCompletion : MonoBehaviour
{
    Quest quest;
    string objective;

    public void CompleteObjective()
    {
        QuestList questList = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestList>();
        questList.CompleteObjective(quest, objective);
    }
    public void AddCompletedObjective(Quest quest, string objective)
    {
        this.quest = quest;
        this.objective = objective;
    }
}
