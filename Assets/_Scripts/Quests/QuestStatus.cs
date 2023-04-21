using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Quests
{
    [System.Serializable]
    public class QuestStatus
    {
        [SerializeField] private Quest quest;
        [SerializeField] private List<string> completedObjectives;
        
        public Quest Quest => quest;

        public int GetCompletedCount() => completedObjectives.Count;

        public bool IsObjectiveCompleted(string objective) => completedObjectives.Contains(objective);
    }
}