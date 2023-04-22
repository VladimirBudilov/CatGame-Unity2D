using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Quests
{
   
    public class QuestStatus
    {
        private Quest quest; 
        private List<string> completedObjectives = new List<string>();
        
        public Quest Quest => quest;

        public int GetCompletedCount() => completedObjectives.Count;

        public bool IsObjectiveCompleted(string objective) => completedObjectives.Contains(objective);

        public QuestStatus(Quest quest)
        {
            this.quest = quest;
        }

        public void CompleteObjective(string objective)
        {
            if(!quest.HasObjective(objective)) return;
            completedObjectives.Add(objective);

        }
    }
}